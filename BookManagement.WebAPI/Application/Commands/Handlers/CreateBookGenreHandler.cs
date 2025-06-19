using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands.Handlers
{
    public class CreateBookGenreHandler : IRequestHandler<CreateBookGenreCommand, BookGenre>
    {
        private readonly IBookGenreRepository _bookGenreRepository;

        public CreateBookGenreHandler(IBookGenreRepository bookGenreRepository)
        {
            _bookGenreRepository = bookGenreRepository;
        }

        public async Task<BookGenre> Handle(CreateBookGenreCommand request, CancellationToken cancellationToken)
        {
            var bookGenre = new BookGenre
            {
                Id = Guid.NewGuid(),
                BookId = request.BookId,
                GenreId = request.GenreId
            };
            var createdBookGenre = await _bookGenreRepository.CreateBookGenre(bookGenre);
            if (createdBookGenre == null)
            {
                throw new Exception("Failed to create book genre");
            }
            return createdBookGenre;
        }
    }
}
