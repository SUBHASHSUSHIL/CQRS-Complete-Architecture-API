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
    public class UserBookRepository : IUserBookRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserBookRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<UserBook> AddUserBookAsync(UserBook userBook)
        {
            var newUserBook = new UserBook
            {
                Id = Guid.NewGuid(),
                UserId = userBook.UserId,
                BookId = userBook.BookId,
                IsDeleted = userBook.IsDeleted
            };
            await _applicationDbContext.UsersBook.AddAsync(newUserBook);
            await _applicationDbContext.SaveChangesAsync();
            return newUserBook;
        }

        public async Task<UserBook> DeleteUserBookAsync(Guid id)
        {
            var userBook = await _applicationDbContext.UsersBook
                .Where(ub => ub.Id == id && !ub.IsDeleted)
                .FirstOrDefaultAsync();
            if (userBook == null)
            {
                throw new KeyNotFoundException($"UserBook with ID {id} not found."); 
            }
            userBook.IsDeleted = true;
            _applicationDbContext.UsersBook.Update(userBook);
            await _applicationDbContext.SaveChangesAsync();
            return userBook;
        }

        public async Task<List<UserBook>> GetAllUserBookAsync()
        {
            var userBooks = await _applicationDbContext.UsersBook
                .Where(ub => !ub.IsDeleted)
                .ToListAsync();
            return userBooks;
        }

        public async Task<UserBook> GetUserBookByIdAsync(Guid id)
        {
            var userBook = await _applicationDbContext.UsersBook
                .Where(ub => ub.Id == id && !ub.IsDeleted)
                .FirstOrDefaultAsync();
            return userBook ?? throw new KeyNotFoundException($"UserBook with ID {id} not found.");
        }

        public async Task<UserBook> UpdateUserBookAsync(UserBook userBook)
        {
            var existingUserBook = await _applicationDbContext.UsersBook
                .Where(ub => ub.Id == userBook.Id && !ub.IsDeleted)
                .FirstOrDefaultAsync();
            if (existingUserBook == null)
                {
                throw new KeyNotFoundException($"UserBook with ID {userBook.Id} not found.");
            }
            existingUserBook.UserId = userBook.UserId;
            existingUserBook.BookId = userBook.BookId;
            existingUserBook.IsDeleted = userBook.IsDeleted;
            _applicationDbContext.UsersBook.Update(existingUserBook);
            await _applicationDbContext.SaveChangesAsync();
            return existingUserBook;
        }
    }
}
