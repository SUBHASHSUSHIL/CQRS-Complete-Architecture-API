using BookManagement.WebAPI.Application.DTOs;
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
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                AuthorName = request.AuthorName,
                IsDeleted = false
            };
            return await _authorRepository.CreateAuthorAsync(author);
        } 
    }
}
