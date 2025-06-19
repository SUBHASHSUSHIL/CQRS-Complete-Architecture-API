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
    public class GetGenreByIdHandler : IRequestHandler<GetGenreByIdQuery, Genre>
    {
        private readonly IGenreRepository _genreRepository;

        public GetGenreByIdHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Genre> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            return await _genreRepository.GetGenreByIdAsync(request.Id);
        }
    }
}
