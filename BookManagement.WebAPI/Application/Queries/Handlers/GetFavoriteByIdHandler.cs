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
    public class GetFavoriteByIdHandler : IRequestHandler<GetFavoriteByIdQuery, Favorite>
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public GetFavoriteByIdHandler(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<Favorite> Handle(GetFavoriteByIdQuery request, CancellationToken cancellationToken)
        {
            var favorite = await _favoriteRepository.GetFavoriteByIdAsync(request.Id);
            if (favorite == null)
            {
                throw new KeyNotFoundException($"Favorite with ID {request.Id} not found.");
            }
            return favorite;
        }
    }
}
