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
    public class GetFavoriteListHandler : IRequestHandler<GetFavoriteListQuery, List<Favorite>>
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public GetFavoriteListHandler(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<List<Favorite>> Handle(GetFavoriteListQuery request, CancellationToken cancellationToken)
        {
            return await _favoriteRepository.GetAllFavoriteAsync();
        }
    }
}
