using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[]? Cover { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublishYear { get; set; }
        public List<BookGenre> BookGenre { get; set; }
        public IEnumerable<Review>? Review { get; set; }
        public IEnumerable<Favorite>? Favorite { get; set; }
        public IEnumerable<UserBook> UserBook { get; set; }
        public bool IsDeleted { get; set; }
    }
}
