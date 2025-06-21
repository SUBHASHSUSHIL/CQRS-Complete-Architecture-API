using BookManagement.WebAPI.Application.DTOs.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Auth.OAuth2.Web.AuthorizationCodeWebApp;

namespace BookManagement.WebAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Application.DTOs.Authentication.AuthResult> Register(Application.DTOs.Authentication.RegisterRequest request);
        Task<Application.DTOs.Authentication.AuthResult> Login(Application.DTOs.Authentication.LoginRequest request);
        Task<Application.DTOs.Authentication.AuthResult> GoogleLogin(GoogleLoginRequest request);
        Task<bool> ConfirmEmail(ConfirmRequest request);
        string GenerateEmailConfirmationToken(string email);
        Task<string> SignOut(string token, string refreshToken);
        Task<Application.DTOs.Authentication.AuthResult> RefreshToken(string refreshToken);
        Task<bool> RevokeToken(string token);
    }
}
