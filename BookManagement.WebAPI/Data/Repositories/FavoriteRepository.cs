using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Data.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FavoriteRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<Favorite> AddAsync(Favorite favorite)
        {
            throw new NotImplementedException();
        }

        public Task<Favorite> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Favorite>> GetAllFavoriteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Favorite> GetFavoriteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Favorite> UpdateAsync(Favorite favorite)
        {
            throw new NotImplementedException();
        }
    }
}
