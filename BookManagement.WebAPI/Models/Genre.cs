using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public IEnumerable<BookGenre> BookGenre { get; set; }
        public bool IsDeleted { get; set; }
    }
}
