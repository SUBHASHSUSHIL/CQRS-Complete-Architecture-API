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
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.Id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {request.Id} not found.");
            }
            book.Title = request.Title;
            book.Description = request.Description;
            book.PublishYear = request.PublishedDate.Year;
            book.BookGenre = request.GenreIds.Select(genreId => new BookGenre
            {
                GenreId = genreId,
                BookId = book.Id
            }).ToList();
            book.Author = new Author
            {
                Id = request.AuthorIds.FirstOrDefault() // Assuming only one author for simplicity
            };
            book.IsDeleted = false;
            var updatedBook = await _bookRepository.UpdateBookAsync(book);
            if (updatedBook == null)
            {
                throw new Exception("Failed to update the book.");
            }
            return updatedBook;
        }
    }
}
