using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs
{
    public class BookGenreDto
    {
       
    }

    public class CreateBookGenreDto
    {
        public Guid BookId { get; set; }
        public Guid GenreId { get; set; }
    }

    public class UpdateBookGenreDto
    {
        public Guid BookId { get; set; }
        public Guid GenreId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
