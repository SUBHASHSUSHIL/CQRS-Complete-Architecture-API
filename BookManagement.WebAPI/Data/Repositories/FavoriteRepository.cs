using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Favorite> AddAsync(Favorite favorite)
        {
            var newFavorite = new Favorite
            {
                Id = Guid.NewGuid(),
                UserId = favorite.UserId,
                BookId = favorite.BookId,
                IsDeleted = favorite.IsDeleted
            };
            await _applicationDbContext.Favorites.AddAsync(newFavorite);
            await _applicationDbContext.SaveChangesAsync();
            return newFavorite;
        }

        public async Task<Favorite> DeleteAsync(Guid id)
        {
            var favorite = await _applicationDbContext.Favorites
                .Where(f => f.Id == id && !f.IsDeleted)
                .FirstOrDefaultAsync();
            if (favorite == null)
                {
                throw new KeyNotFoundException($"Favorite with ID {id} not found.");
            }
            favorite.IsDeleted = true;
            _applicationDbContext.Favorites.Update(favorite);
            await _applicationDbContext.SaveChangesAsync();
            return favorite;
        }

        public async Task<List<Favorite>> GetAllFavoriteAsync()
        {
            var favorites = await _applicationDbContext.Favorites
                .Where(f => !f.IsDeleted)
                .ToListAsync();
            return favorites;
        }

        public async Task<Favorite> GetFavoriteByIdAsync(Guid id)
        {
            var favorite = await _applicationDbContext.Favorites
                .Where(f => f.Id == id && !f.IsDeleted)
                .FirstOrDefaultAsync();
            return favorite ?? throw new KeyNotFoundException($"Favorite with ID {id} not found.");
        }

        public async Task<Favorite> UpdateAsync(Favorite favorite)
        {
            var existingFavorite = await _applicationDbContext.Favorites
                .Where(f => f.Id == favorite.Id && !f.IsDeleted)
                .FirstOrDefaultAsync();
            if (existingFavorite == null)
                {
                throw new KeyNotFoundException($"Favorite with ID {favorite.Id} not found.");
            }
            existingFavorite.UserId = favorite.UserId;
            existingFavorite.BookId = favorite.BookId;
            existingFavorite.IsDeleted = favorite.IsDeleted;
            _applicationDbContext.Favorites.Update(existingFavorite);
            await _applicationDbContext.SaveChangesAsync();
            return existingFavorite;
        }
    }
}
