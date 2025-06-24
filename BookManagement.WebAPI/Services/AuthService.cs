﻿using AutoMapper;
using BookManagement.WebAPI.Application.Common;
using BookManagement.WebAPI.Application.DTOs.Authentication;
using BookManagement.WebAPI.Authentication.Interfaces;
using BookManagement.WebAPI.Helpers;
using BookManagement.WebAPI.Helpers.Validator;
using BookManagement.WebAPI.Models;
using BookManagement.WebAPI.Services.Interfaces;
using FluentValidation.Validators;
using Google.Apis.Auth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, IMailService mailService, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }

        public async Task<AuthResult> Register(RegisterRequest request)
        {
            var authResult = new AuthResult();
            if (!EmailValidator.IsValidEmail(request.email))
            {
                authResult.Message = "Invalid Email";
                return authResult;
            }

            if(await _unitOfWork.Users.FindByEmailAsync(request.email) != null)
            {
                authResult.Message = "Email already exists";
                return authResult;
            }

            var pendingUser = await _unitOfWork.PenddingUsers.FindAsync(u => u.Email == request.email);
            if (pendingUser != null)
            {
                if (pendingUser.EmailVerificationTokenExpires < DateTime.UtcNow)
                {
                    await _unitOfWork.PenddingUsers.DeleteAsync(pendingUser);
                }
                else
                {
                    authResult.Message = "Email already registered, please confirm your email.";
                    return authResult;
                }
            }

            if (!string.IsNullOrEmpty(request.Phone))
            {
                if (!PhoneValidator.IsValid(request.Phone))
                {
                    authResult.Message = "Invalid Phone Number";
                    return authResult;
                }
                if (await _unitOfWork.Users.FindByPhoneAsync(request.Phone) != null)
                {
                    authResult.Message = "Phone number already exists";
                    return authResult;
                }
                var pendUser = await _unitOfWork.PenddingUsers.FindAsync(u => u.Phone == request.Phone);
                if (pendUser != null)
                {
                    if (pendUser.EmailVerificationTokenExpires < DateTime.UtcNow)
                    {
                        await _unitOfWork.PenddingUsers.DeleteAsync(pendUser);
                    }
                    else
                    {
                        authResult.Message = "Phone number pending to another user, Please verify your email or wait for 1 hour";
                        return authResult;
                    }
                }

            }

            if (!PasswordValidator.IsValid(request.password))
            {
                return new AuthResult
                {
                    Message = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character.\n" + "Example: Abc123!@#"
                };
            }

            var newUser = new PenddingUser
            {
                Email = request.email,
                Phone = request.Phone,
                Name = request.FullName,
                HashPassword = PasswordHelper.HashPassword(request.password),
                EmailVerificationToken = GenerateEmailConfirmationToken(request.email),
                EmailVerificationTokenExpires = DateTime.UtcNow.AddHours(1),
                IsVerified = false
            };

            await _unitOfWork.PenddingUsers.AddAsync(newUser);

            authResult.AuthProvider = "Email";
            authResult.Email = newUser.Email;
            authResult.Name = newUser.Name;
            authResult.Phone = newUser.Phone;
            authResult.EmailVerificationToken = newUser.EmailVerificationToken;
            authResult.EmailVerificationTokenExpires = newUser.EmailVerificationTokenExpires;
            authResult.IsAuthenticated = newUser.IsVerified;

            return authResult;
        }

        public async Task<AuthResult> Login(LoginRequest request)
        {
            var authResult = new AuthResult();
            if (!EmailValidator.IsValidEmail(request.email))
            {
                authResult.Message = "Invalid Email";
                return authResult;
            }
            var user = await _unitOfWork.Users.FindAsync(u => u.Email == request.email, ["RefreshTokens"]);
            if (user == null || !PasswordHelper.VerifyPassword(request.password, user.PasswordHash))
            {
                authResult.Message = "Email Or Password Is Incorrect";
                return authResult;
            }
            if (user.IsDeleted)
            {
                authResult.Message = "This account is locked contact us to unlock";
                return authResult;
            }

            var jwtSecurityToken = await _jwtTokenGenerator.GenerateJwtToken(user);
            var roleList = await _unitOfWork.Roles.GetRolesAsync(user);

            authResult = _mapper.Map<AuthResult>(user);
            authResult.Roles = roleList;
            authResult.Token = jwtSecurityToken;

            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                authResult.RefreshToken = activeRefreshToken.Token;
                authResult.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();
                authResult.RefreshToken = refreshToken.Token;
                authResult.RefreshTokenExpiration = refreshToken.ExpiresOn;

                user.RefreshTokens.Add(refreshToken);
                await _unitOfWork.Users.UpdateAsync(user);
            }
            return authResult;
        }

        public async Task<AuthResult> GoogleLogin(GoogleLoginRequest request)
        {
            var authResult = new AuthResult();
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>
                {
                    "462255915759-dlojksj0qrrn8kjj6j2ehvjs0pvi67lp.apps.googleusercontent.com"
                }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);

                var userId = payload.Subject;
                var email = payload.Email;
                var name = payload.Name;

                var user = await _unitOfWork.Users.FindAsync(u => u.Email == email, ["RefreshTokens"]);
                if (user is null)
                {
                    var newUser = new User
                    {
                        Name = name,
                        Email = email,
                        UserName = email.Split('@')[0],
                        AuthProvider = "Google",
                        GoogleId = userId,
                    };

                    await _unitOfWork.Users.AddAsync(newUser);
                    await _unitOfWork.Users.AddToRoleAsync(newUser.Id, Roles.User.GetDescription());

                    var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

                    authResult = _mapper.Map<AuthResult>(newUser);

                    authResult.Roles = await _unitOfWork.Roles.GetRolesAsync(newUser);
                    authResult.Token = await _jwtTokenGenerator.GenerateJwtToken(newUser);
                    authResult.RefreshToken = refreshToken.Token;
                    authResult.RefreshTokenExpiration = refreshToken.ExpiresOn;

                    newUser.RefreshTokens.Add(refreshToken);
                    await _unitOfWork.Users.UpdateAsync(newUser);

                    return authResult;
                }

                var jwtSecurityToken = await _jwtTokenGenerator.GenerateJwtToken(user);
                var roleList = await _unitOfWork.Roles.GetRolesAsync(user);


                authResult = _mapper.Map<AuthResult>(user);

                authResult.AuthProvider = user.AuthProvider;
                authResult.Roles = roleList;
                authResult.Token = jwtSecurityToken;

                if (user.RefreshTokens.Any(t => t.IsActive))
                {
                    var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                    authResult.RefreshToken = activeRefreshToken.Token;
                    authResult.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
                }
                else
                {
                    var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();
                    authResult.RefreshToken = refreshToken.Token;
                    authResult.RefreshTokenExpiration = refreshToken.ExpiresOn;

                    user.RefreshTokens.Add(refreshToken);
                    await _unitOfWork.Users.UpdateAsync(user);
                }
                return authResult;

            }
            catch (Exception ex)
            {
                authResult.Message = ex.Message;
                return authResult;
            }
        }

        public async Task<bool> ConfirmEmail(ConfirmRequest request)
        {
            var user = await _unitOfWork.PenddingUsers.FindAsync(u => u.Email == request.Email);
            if (user is null || user.EmailVerificationToken != request.Token)
                throw new Exception("Invalid confirmation link");

            if (user.EmailVerificationTokenExpires < DateTime.UtcNow)
                throw new Exception("Confirmation link has expired");

            if (user.IsVerified)
                throw new Exception("Email already confirmed");

            user.IsVerified = true;
            user.EmailVerificationToken = null;
            user.EmailVerificationTokenExpires = null;

            var newUser = _mapper.Map<User>(user);
            newUser.UserName = user.Email.Split('@')[0];
            newUser.AuthProvider = "Email";
            newUser.PasswordHash = user.HashPassword;

            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.Users.AddToRoleAsync(newUser.Id, Roles.User.GetDescription());

            await _unitOfWork.PenddingUsers.DeleteAsync(user);

            return true;
        }

        public string GenerateEmailConfirmationToken(string email)
        {
            var token = Guid.NewGuid().ToString() + Guid.NewGuid().ToString();
            token = token.Replace("-", "");
            return token;
        }

        public async Task<string> SignOut(string token, string refreshToken)
        {
            try
            {
                if (token == null || refreshToken == null)
                    return "Invalid request";

                if (!string.IsNullOrEmpty(token))
                {
                    var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                    var expiration = jwtToken.ValidTo;

                    var blackListToken = new BlacklistedToken
                    {
                        Token = token,
                        Expiration = expiration
                    };

                    var refresh = await _unitOfWork.RefreshTokens.FindAsync(rt => rt.Token == refreshToken);

                    if (refresh is null)
                        return "Invalid refresh token";

                    if (!refresh.IsActive)
                    {
                        await _unitOfWork.blacklistedTokens.AddAsync(blackListToken);
                        return "Signed out successfully";
                    }
                    await _unitOfWork.blacklistedTokens.AddAsync(blackListToken);
                    await RevokeToken(refreshToken);
                }
                return "Signed out successfully";
            }
            catch (Exception e)
            {
                return $"Error signing out: {e.Message}";
            }
        }

        public async Task<AuthResult> RefreshToken(string token)
        {
            var authResult = new AuthResult();
            if (string.IsNullOrEmpty(token))
            {
                authResult.IsAuthenticated = false;
                authResult.Message = "Invalid Refresh Token";
                return authResult;
            }

            var user = await _unitOfWork.Users.FindAsync(u => u.RefreshTokens.Any(t => t.Token == token), ["RefreshTokens"]);

            if (user is null)
            {
                authResult.IsAuthenticated = false;
                authResult.Message = "Invalid Refresh Token";
                return authResult;
            }

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
            {
                authResult.IsAuthenticated = false;
                authResult.Message = "Invalid Refresh Token";
                return authResult;
            }

            var jwtToken = await _jwtTokenGenerator.GenerateJwtToken(user);
            var roles = await _unitOfWork.Roles.GetRolesAsync(user);

            authResult = _mapper.Map<AuthResult>(user);
            authResult.IsAuthenticated = true;
            authResult.Roles = roles;
            authResult.Token = jwtToken;

            return authResult;
        }

        
        public async Task<bool> RevokeToken(string token)
        {
            var user = await _unitOfWork.Users.FindAsync(u => u.RefreshTokens.Any(t => t.Token == token), ["RefreshTokens"]);

            if (user is null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);
            if (!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow;
            await _unitOfWork.Users.UpdateAsync(user);

            return true;
        }
    }
}
