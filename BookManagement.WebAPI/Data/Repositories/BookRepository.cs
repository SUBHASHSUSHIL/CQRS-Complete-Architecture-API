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
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var newBook = new Book
            {
                Id = Guid.NewGuid(),
                Title = book.Title,
                AuthorId = book.AuthorId,
                Description = book.Description,
                Cover = book.Cover,
                IsDeleted = book.IsDeleted,
                PublishYear = book.PublishYear
            };
            await _applicationDbContext.Books.AddAsync(newBook);
            await _applicationDbContext.SaveChangesAsync();
            return newBook;
        }

        public Task DeleteBookAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetBookAllAsync()
        {
            var books = await _applicationDbContext.Books
                .Where(b => !b.IsDeleted)
                .ToListAsync();
            return books;
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            var book = await _applicationDbContext.Books
                .Where(b => b.Id == id && !b.IsDeleted)
                .FirstOrDefaultAsync();
            return book ?? throw new KeyNotFoundException($"Book with ID {id} not found.");
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var existingBook = await _applicationDbContext.Books
                .Where(b => b.Id == book.Id && !b.IsDeleted)
                .FirstOrDefaultAsync();
            if (existingBook == null)
                {
                throw new KeyNotFoundException($"Book with ID {book.Id} not found.");
            }
            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.Cover = book.Cover;
            existingBook.AuthorId = book.AuthorId;
            existingBook.PublishYear = book.PublishYear;
            existingBook.IsDeleted = book.IsDeleted;
            _applicationDbContext.Books.Update(existingBook);
            await _applicationDbContext.SaveChangesAsync();
            return existingBook;
        }
    }
}
