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
    public class UpdateBookGenreHandler : IRequestHandler<UpdateBookGenreCommand, BookGenre>
    {
        private readonly IBookGenreRepository _bookGenreRepository;

        public UpdateBookGenreHandler(IBookGenreRepository bookGenreRepository)
        {
            _bookGenreRepository = bookGenreRepository;
        }

        public async Task<BookGenre> Handle(UpdateBookGenreCommand request, CancellationToken cancellationToken)
        {
            var bookGenre = await _bookGenreRepository.GetBookGenreById(request.Id);
            if (bookGenre == null)
            {
                throw new KeyNotFoundException($"BookGenre with ID {request.Id} not found.");
            }
            bookGenre.BookId = request.BookId;
            bookGenre.GenreId = request.GenreId;
            var updatedBookGenre = await _bookGenreRepository.UpdateBookGenre(bookGenre);
            if (updatedBookGenre == null)
            {
                throw new Exception("Failed to update book genre");
            }
            return updatedBookGenre;
        }
    }
}
