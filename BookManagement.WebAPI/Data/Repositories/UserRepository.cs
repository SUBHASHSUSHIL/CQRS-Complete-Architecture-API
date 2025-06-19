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

        public Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
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

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
