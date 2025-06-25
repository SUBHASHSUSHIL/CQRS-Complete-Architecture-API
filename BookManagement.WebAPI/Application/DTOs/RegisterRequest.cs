using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs
{
    public class RegisterRequest
    {
        public string FullName { get; set; }
        public string email { get; set; }
        public string? Phone { get; set; }
        public string password { get; set; }
    }
}
