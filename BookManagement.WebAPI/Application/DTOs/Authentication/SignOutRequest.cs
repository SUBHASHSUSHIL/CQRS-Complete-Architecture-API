using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs.Authentication
{
    public class SignOutRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
