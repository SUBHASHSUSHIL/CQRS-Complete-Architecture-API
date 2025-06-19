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
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GenreRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Genre> AddGenreAsync(Genre genre)
        {
            var newGenre = new Genre
            {
                Id = Guid.NewGuid(),
                GenreName = genre.GenreName,
                IsDeleted = genre.IsDeleted
            };
            await _applicationDbContext.Genres.AddAsync(newGenre);
            await _applicationDbContext.SaveChangesAsync();
            return newGenre;
        }

        public async Task<Genre> DeleteGenreAsync(Guid id)
        {
            var genre = await _applicationDbContext.Genres
                .Where(g => g.Id == id && !g.IsDeleted)
                .FirstOrDefaultAsync();
            if (genre == null)
                {
                throw new KeyNotFoundException($"Genre with ID {id} not found.");
            }
            genre.IsDeleted = true;
            _applicationDbContext.Genres.Update(genre);
            await _applicationDbContext.SaveChangesAsync();
            return genre;
        }

        public async Task<List<Genre>> GetAllGenreAsync()
        {
            var genres = await _applicationDbContext.Genres
                .Where(g => !g.IsDeleted)
                .ToListAsync();
            return genres;
        }

        public async Task<Genre> GetGenreByIdAsync(Guid id)
        {
            var genre = await _applicationDbContext.Genres
                .Where(g => g.Id == id && !g.IsDeleted)
                .FirstOrDefaultAsync();
            return genre ?? throw new KeyNotFoundException($"Genre with ID {id} not found.");
        }

        public async Task<Genre> UpdateGenreAsync(Genre genre)
        {
            var existingGenre = await _applicationDbContext.Genres
                .Where(g => g.Id == genre.Id && !g.IsDeleted)
                .FirstOrDefaultAsync();
            if (existingGenre == null)
                {
                throw new KeyNotFoundException($"Genre with ID {genre.Id} not found.");
            }
            existingGenre.GenreName = genre.GenreName;
            existingGenre.IsDeleted = genre.IsDeleted;
            _applicationDbContext.Genres.Update(existingGenre);
            await _applicationDbContext.SaveChangesAsync();
            return existingGenre;
        }
    }
}
