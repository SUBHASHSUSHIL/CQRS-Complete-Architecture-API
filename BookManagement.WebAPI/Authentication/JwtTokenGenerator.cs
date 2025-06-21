using BookManagement.WebAPI.Authentication.Interfaces;
using BookManagement.WebAPI.Data;
using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ApplicationDbContext _applicationDbContext;

        public JwtTokenGenerator(JwtSettings jwtSettings, ApplicationDbContext applicationDbContext)
        {
            _jwtSettings = jwtSettings;
            _applicationDbContext = applicationDbContext;
        }

        public Task<string> GenerateJwtToken(User user)
        {
            throw new NotImplementedException();
        }

        public RefreshToken GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}
