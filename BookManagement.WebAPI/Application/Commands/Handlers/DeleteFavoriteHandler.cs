using BookManagement.WebAPI.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands.Handlers
{
    public class DeleteFavoriteHandler : IRequestHandler<DeleteFavoriteCommand, Guid>
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public DeleteFavoriteHandler(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<Guid> Handle(DeleteFavoriteCommand request, CancellationToken cancellationToken)
        {
            var favorite = await _favoriteRepository.GetFavoriteByIdAsync(request.Id);
            if (favorite == null)
            {
                throw new Exception("Favorite not found");
            }
            favorite.IsDeleted = true; // Assuming you want to mark it as deleted
            var deletedFavorite = await _favoriteRepository.UpdateAsync(favorite);
            if (deletedFavorite == null)
            {
                throw new Exception("Failed to delete favorite");
            }
            return deletedFavorite.Id;
        }
    }
}
