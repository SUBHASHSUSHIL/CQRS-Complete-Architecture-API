using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public IEnumerable<Book> Book { get; set; }
        public bool IsDeleted { get; set; }
    }
}
