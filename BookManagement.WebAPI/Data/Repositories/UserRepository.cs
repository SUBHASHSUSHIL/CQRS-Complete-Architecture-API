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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            var existingUser = await _applicationDbContext.Users
                .FirstOrDefaultAsync(u => u.Email == user.Email || u.UserName == user.UserName);
            if (existingUser != null)
                {
                throw new InvalidOperationException("User with the same email or username already exists.");
            }
            user.Id = Guid.NewGuid();
            _applicationDbContext.Users.Add(user);
            await _applicationDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(Guid id)
        {
            var user = await _applicationDbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            _applicationDbContext.Users.Remove(user);
            await _applicationDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            var user = await _applicationDbContext.Users.ToListAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _applicationDbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            return user ?? throw new KeyNotFoundException($"User with ID {id} not found.");
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _applicationDbContext.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");
            }
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.UserName = user.UserName;
            existingUser.Phone = user.Phone;
            existingUser.Photo = user.Photo;
            existingUser.IsEmailConfirmed = user.IsEmailConfirmed;
            existingUser.EmailConformationToken = user.EmailConformationToken;
            existingUser.EmailConfirmationTokenExpiration = user.EmailConfirmationTokenExpiration;
            existingUser.IsToken = user.IsToken;
            existingUser.UserRole = user.UserRole;
            existingUser.Review = user.Review;
            existingUser.Favorite = user.Favorite;
            existingUser.UserBook = user.UserBook;
            existingUser.RefreshTokens = user.RefreshTokens;
            _applicationDbContext.Users.Update(existingUser);
            await _applicationDbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
