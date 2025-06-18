using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
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

        public Task<UserRole> AddUserRoleAsync(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> DeleteUserRoleAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserRole>> GetAllUserRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> GetUserRoleByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> UpdateUserRoleAsync(UserRole userRole)
        {
            throw new NotImplementedException();
        }
    }
}
