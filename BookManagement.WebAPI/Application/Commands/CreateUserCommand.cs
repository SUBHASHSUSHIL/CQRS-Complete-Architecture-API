using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public byte[]? Photo { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public string? EmailConformationToken { get; set; }
        public DateTime? EmailConfirmationTokenExpiration { get; set; }
        public bool IsToken { get; set; } = false;
        public CreateUserCommand(string firstName, string lastName, string email, string userName, string password, string? phone = null, byte[]? photo = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
            Phone = phone;
            Photo = photo;
        }

        public CreateUserCommand(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }
    }
}
