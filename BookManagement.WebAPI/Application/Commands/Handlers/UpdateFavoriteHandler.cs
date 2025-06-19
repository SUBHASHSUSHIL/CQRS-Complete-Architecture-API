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
    public class UpdateFavoriteHandler : IRequestHandler<UpdateFavoriteCommand, Favorite>
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public UpdateFavoriteHandler(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<Favorite> Handle(UpdateFavoriteCommand request, CancellationToken cancellationToken)
        {
            var existingFavorite = await _favoriteRepository.GetFavoriteByIdAsync(request.Id);
            if (existingFavorite == null)
            {
                throw new Exception("Favorite not found");
            }
            existingFavorite.UserId = request.UserId;
            existingFavorite.BookId = request.BookId;
            existingFavorite.IsDeleted = false; // Assuming you want to mark it as not deleted on update
            var updatedFavorite = await _favoriteRepository.UpdateAsync(existingFavorite);
            if (updatedFavorite == null)
            {
                throw new Exception("Failed to update favorite");
            }
            return updatedFavorite;
        }
    }
}
