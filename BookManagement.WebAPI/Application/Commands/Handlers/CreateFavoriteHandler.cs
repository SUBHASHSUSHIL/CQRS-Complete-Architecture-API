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
    public class CreateFavoriteHandler : IRequestHandler<CreateFavoriteCommand, Favorite>
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public CreateFavoriteHandler(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<Favorite> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
        {
            var favorite = new Favorite
            {
                UserId = request.UserId,
                BookId = request.BookId
            };
            var createdFavorite = await _favoriteRepository.AddAsync(favorite);
            if (createdFavorite == null)
            {
                throw new Exception("Failed to create favorite");
            }
            return createdFavorite;
        }
    }
}
