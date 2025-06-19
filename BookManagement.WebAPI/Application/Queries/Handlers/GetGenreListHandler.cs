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
    public class GetGenreListHandler : IRequestHandler<GetGenreListQuery, List<Genre>>
    {
        private readonly IGenreRepository _genreRepository;

        public GetGenreListHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<List<Genre>> Handle(GetGenreListQuery request, CancellationToken cancellationToken)
        {
            return await _genreRepository.GetAllGenreAsync();
        }
    }
}
