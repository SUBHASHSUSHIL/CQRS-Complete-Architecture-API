using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ExpiresOn { get; set; } = DateTime.UtcNow.AddDays(1);
        public DateTime? RevokedOn { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
        public bool IsActive => RevokedOn == null && !IsExpired;
    }
}
