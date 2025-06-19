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
    public class GetBookListHandler : IRequestHandler<GetBookListQuery, List<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookListHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBookAllAsync();
        }
    }
}
