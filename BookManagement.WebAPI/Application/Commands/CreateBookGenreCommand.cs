using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class CreateBookGenreCommand : IRequest<BookGenre>
    {
        public Guid BookId { get; set; }
        public Guid GenreId { get; set; }
        public CreateBookGenreCommand(Guid bookId, Guid genreId)
        {
            BookId = bookId;
            GenreId = genreId;
        }
    }
}
