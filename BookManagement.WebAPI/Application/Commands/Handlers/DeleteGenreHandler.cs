using BookManagement.WebAPI.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands.Handlers
{
    public class DeleteGenreHandler : IRequestHandler<DeleteGenreCommand, Guid>
    {
        private readonly IGenreRepository _genreRepository;

        public DeleteGenreHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Guid> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(request.Id);
            if (genre == null)
            {
                throw new Exception("Genre not found");
            }
            genre.IsDeleted = true; // Assuming you want to mark it as deleted
            var deletedGenre = await _genreRepository.UpdateGenreAsync(genre);
            if (deletedGenre == null)
            {
                throw new Exception("Failed to delete genre");
            }
            return deletedGenre.Id;
        }
    }
}
