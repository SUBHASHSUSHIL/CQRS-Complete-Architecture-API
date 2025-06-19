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
    public class UpdateGenreHandler : IRequestHandler<UpdateGenreCommand, Genre>
    {
        private readonly IGenreRepository _genreRepository;

        public UpdateGenreHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Genre> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var existingGenre = await _genreRepository.GetGenreByIdAsync(request.Id);
            if (existingGenre == null)
            {
                throw new Exception("Genre not found");
            }
            existingGenre.GenreName = request.GenreName;
            existingGenre.IsDeleted = false; // Assuming you want to mark it as not deleted on update
            var updatedGenre = await _genreRepository.UpdateGenreAsync(existingGenre);
            if (updatedGenre == null)
            {
                throw new Exception("Failed to update genre");
            }
            return updatedGenre;
        }
    }
}
