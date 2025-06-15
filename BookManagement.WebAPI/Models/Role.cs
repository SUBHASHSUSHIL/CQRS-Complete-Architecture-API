using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<UserRole>? UserRole { get; set; }
        public bool IsDeleted { get; set; }
    }
}
