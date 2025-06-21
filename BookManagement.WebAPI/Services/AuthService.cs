using BookManagement.WebAPI.Application.DTOs.Authentication;
using BookManagement.WebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Services
{
    public class AuthService : IAuthService
    {

        public Task<bool> ConfirmEmail(ConfirmRequest request)
        {
            throw new NotImplementedException();
        }

        public string GenerateEmailConfirmationToken(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> GoogleLogin(GoogleLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> Login(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> RefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RevokeToken(string token)
        {
            throw new NotImplementedException();
        }

        public Task<string> SignOut(string token, string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
