using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Models
{
    public class BlacklistedToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
