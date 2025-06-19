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
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
           var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                AuthorId = request.AuthorId,
                IsDeleted = false
            };
            var createdBook = await _bookRepository.AddBookAsync(book);
            
            return createdBook; 
        }
    }
}
