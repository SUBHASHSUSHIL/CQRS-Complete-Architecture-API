using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public string ReviewContent { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; } = null;
        public bool IsDeleted { get; set; }
    }
}
