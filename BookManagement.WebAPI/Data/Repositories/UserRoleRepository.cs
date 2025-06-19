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
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRoleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<UserRole> AddUserRoleAsync(UserRole userRole)
        {
            var existingUserRole = await _applicationDbContext.UserRoles
                .FirstOrDefaultAsync(ur => ur.RoleId == userRole.RoleId && ur.UserId == userRole.UserId);
            if (existingUserRole != null)
            {
                throw new InvalidOperationException("UserRole with the same RoleId and UserId already exists."); 
            }
            userRole.Id = Guid.NewGuid();
            _applicationDbContext.UserRoles.Add(userRole);
            await _applicationDbContext.SaveChangesAsync();
            return userRole;
        }

        public async Task<UserRole> DeleteUserRoleAsync(Guid id)
        {
            var userRole = await _applicationDbContext.UserRoles.FindAsync(id);
            if (userRole == null)
            {
                throw new KeyNotFoundException($"UserRole with ID {id} not found.");
            }
            userRole.IsDeleted = true;
            _applicationDbContext.UserRoles.Update(userRole);
            await _applicationDbContext.SaveChangesAsync();
            return userRole;
        }

        public async Task<List<UserRole>> GetAllUserRoleAsync()
        {
            var userRoles = await _applicationDbContext.UserRoles.Where(ur => !ur.IsDeleted).ToListAsync();
            return userRoles;
        }

        public async Task<UserRole> GetUserRoleByIdAsync(Guid id)
        {
            var userRole = await _applicationDbContext.UserRoles
                .Where(ur => ur.Id == id && !ur.IsDeleted)
                .FirstOrDefaultAsync();
            return userRole ?? throw new KeyNotFoundException($"UserRole with ID {id} not found.");
        }

        public async Task<UserRole> UpdateUserRoleAsync(UserRole userRole)
        {
            var existingUserRole = await _applicationDbContext.UserRoles.FindAsync(userRole.Id);
            if (existingUserRole == null)
            {
                throw new KeyNotFoundException($"UserRole with ID {userRole.Id} not found.");
            }
            existingUserRole.UserId = userRole.UserId;
            existingUserRole.RoleId = userRole.RoleId;
            existingUserRole.IsDeleted = userRole.IsDeleted;
            _applicationDbContext.UserRoles.Update(existingUserRole);
            await _applicationDbContext.SaveChangesAsync();
            return existingUserRole;
        }
    }
}
