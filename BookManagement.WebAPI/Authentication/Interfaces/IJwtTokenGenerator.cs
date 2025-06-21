using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Authentication.Interfaces
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateJwtToken(User user);
        RefreshToken GenerateRefreshToken();
    }
}
