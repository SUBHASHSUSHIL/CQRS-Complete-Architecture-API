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
    public class CreateGenreHandler : IRequestHandler<CreateGenreCommand, Genre>
    {
        private readonly IGenreRepository _genreRepository;

        public CreateGenreHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Genre> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                GenreName = request.GenreName
            };
            var createdGenre = await _genreRepository.AddGenreAsync(genre);
            if (createdGenre == null)
            {
                throw new Exception("Failed to create genre");
            }
            return createdGenre;
        }
    }
}
