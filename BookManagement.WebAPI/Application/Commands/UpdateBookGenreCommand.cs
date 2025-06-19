using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class UpdateBookGenreCommand : IRequest<BookGenre>, IBaseRequest
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid GenreId { get; set; }
        public bool IsDeleted { get; set; }

        // Constructor to fix CS1729
        public UpdateBookGenreCommand(Guid id, Guid bookId, Guid genreId, bool isDeleted)
        {
            Id = id;
            BookId = bookId;
            GenreId = genreId;
            IsDeleted = isDeleted;
        }
    }
}
