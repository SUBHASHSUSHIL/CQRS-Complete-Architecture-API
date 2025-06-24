using BookManagement.WebAPI.Application.DTOs.Authentication.User;
using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs
{
    public class UserDto : BasicUserDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }

    public class BasicUserDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string? Phone { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }

    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public byte[]? Photo { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string? EmailConformationToken { get; set; }
        public DateTime? EmailConfirmationTokenExpiration { get; set; }
        public bool IsToken { get; set; }
    }

    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public byte[]? Photo { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string? EmailConformationToken { get; set; }
        public DateTime? EmailConfirmationTokenExpiration { get; set; }
        public bool IsToken { get; set; }
    }
}
