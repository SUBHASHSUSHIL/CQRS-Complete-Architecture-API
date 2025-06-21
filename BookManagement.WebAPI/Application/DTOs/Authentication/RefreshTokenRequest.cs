using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs.Authentication
{
    public class RefreshTokenRequest
    {
        public string refreshToken { get; set; }
    }
}
