using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Queries.Handlers
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorByIdHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetAuthorByIdAsync(request.Id);
                   //?? throw new KeyNotFoundException($"Author with ID {request.Id} not found.");
        }
    }
}
