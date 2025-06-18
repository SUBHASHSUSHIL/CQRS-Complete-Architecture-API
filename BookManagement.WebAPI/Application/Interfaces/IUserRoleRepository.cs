using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<List<UserRole>> GetAllUserRoleAsync();
        Task<UserRole> GetUserRoleByIdAsync(Guid id);
        Task<UserRole> AddUserRoleAsync(UserRole userRole);
        Task<UserRole> UpdateUserRoleAsync(UserRole userRole);
        Task<UserRole> DeleteUserRoleAsync(Guid id);
    }
}
