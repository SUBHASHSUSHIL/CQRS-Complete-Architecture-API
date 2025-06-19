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
    public class BookGenreRepository : IBookGenreRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookGenreRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BookGenre> CreateBookGenre(BookGenre bookGenre)
        {
            var newBookGenre = new BookGenre
            {
                Id = Guid.NewGuid(),
                BookId = bookGenre.BookId,
                GenreId = bookGenre.GenreId,
                IsDeleted = bookGenre.IsDeleted
            };
            await _applicationDbContext.BookGenres.AddAsync(newBookGenre);
            await _applicationDbContext.SaveChangesAsync();
            return newBookGenre;
        }

        public async Task<BookGenre> DeleteBookGenreById(Guid id)
        {
            var bookGenre = await _applicationDbContext.BookGenres
                .Where(bg => bg.Id == id && !bg.IsDeleted)
                .FirstOrDefaultAsync();
            if (bookGenre == null)
            {
                throw new KeyNotFoundException($"Book genre ID {id} not found.");
            }
            bookGenre.IsDeleted = true;
            _applicationDbContext.BookGenres.Update(bookGenre);
            await _applicationDbContext.SaveChangesAsync();
            return bookGenre;
        }

        public async Task<List<BookGenre>> GetBookGenreAll()
        {
            var bookGenres = await _applicationDbContext.BookGenres
                .Where(bg => !bg.IsDeleted)
                .ToListAsync();
            return bookGenres;
        }

        public async Task<BookGenre> GetBookGenreById(Guid id)
        {
            var bookGenre = await _applicationDbContext.BookGenres
                .Where(bg => bg.Id == id && !bg.IsDeleted)
                .FirstOrDefaultAsync();
            return bookGenre ?? throw new KeyNotFoundException("Book genre not found.");
        }

        public async Task<BookGenre> UpdateBookGenre(BookGenre bookGenre)
        {
            var existingBookGenre = await _applicationDbContext.BookGenres
                .Where(bg => bg.Id == bookGenre.Id && !bg.IsDeleted)
                .FirstOrDefaultAsync();
            if (existingBookGenre == null)
                {
                throw new KeyNotFoundException($"Book genre ID {bookGenre.Id} not found.");
            }
            existingBookGenre.GenreId = bookGenre.GenreId;
            existingBookGenre.BookId = bookGenre.BookId;
            existingBookGenre.IsDeleted = bookGenre.IsDeleted;
            _applicationDbContext.BookGenres.Update(existingBookGenre);
            await _applicationDbContext.SaveChangesAsync();
            return bookGenre;
        }
    }
}
