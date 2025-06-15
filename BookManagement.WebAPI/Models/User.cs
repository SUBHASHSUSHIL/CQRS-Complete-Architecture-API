using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Models
{
    public class User
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
        public IEnumerable<UserRole> UserRole { get; set; }
        public IEnumerable<Review>? Review { get; set; }
        public IEnumerable<Favorite>? Favorite { get; set; }
        public IEnumerable<UserBook>? UserBook { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }
    }
}
