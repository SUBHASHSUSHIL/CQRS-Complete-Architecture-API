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
    public class GetBookGenreListHandler : IRequestHandler<GetBookGenreListQuery, List<BookGenre>>
    {
        private readonly IBookGenreRepository _bookGenreRepository;

        public GetBookGenreListHandler(IBookGenreRepository bookGenreRepository)
        {
            _bookGenreRepository = bookGenreRepository;
        }

        public async Task<List<BookGenre>> Handle(GetBookGenreListQuery request, CancellationToken cancellationToken)
        {
            return await _bookGenreRepository.GetBookGenreAll();
        }
    }
}
