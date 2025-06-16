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
    public class GetAuthorListHandler : IRequestHandler<GetAuthorListQuery, List<Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorListHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> Handle(GetAuthorListQuery request, CancellationToken cancellationToken)
        {
            return await _authorRepository.GetAllAuthorsAsync();
        }
    }
}
