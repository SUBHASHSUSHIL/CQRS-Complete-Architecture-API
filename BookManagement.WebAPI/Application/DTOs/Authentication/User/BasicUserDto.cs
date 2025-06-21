using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs.Authentication.User
{
    public class BasicUserDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string? Phone { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
