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
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, Guid>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Guid> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(request.Id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {request.Id} not found.");
            }
            var deletedAuthor = await _authorRepository.DeleteAuthorAsync(request.Id);
            return deletedAuthor.Id;
        }
    }
}
