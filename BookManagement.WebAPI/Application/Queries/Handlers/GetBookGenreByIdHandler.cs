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
    public class GetBookGenreByIdHandler : IRequestHandler<GetBookGenreByIdQuery, BookGenre>
    {
        private readonly IBookGenreRepository _bookGenreRepository;

        public GetBookGenreByIdHandler(IBookGenreRepository bookGenreRepository)
        {
            _bookGenreRepository = bookGenreRepository;
        }

        public async Task<BookGenre> Handle(GetBookGenreByIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookGenreRepository.GetBookGenreById(request.Id);
        }
    }
}
