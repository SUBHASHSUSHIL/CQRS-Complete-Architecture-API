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
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(request.Id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {request.Id} not found.");
            }

            author.AuthorName = request.AuthorName;
            author.IsDeleted = request.IsDeleted;

            await _authorRepository.UpdateAuthorAsync(author);
            return author;
        }
    }
}
