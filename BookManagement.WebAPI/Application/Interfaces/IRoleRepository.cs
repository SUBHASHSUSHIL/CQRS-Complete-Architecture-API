using BookManagement.WebAPI.Authentication.Interfaces;
using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<List<string>?> GetRolesAsync(User user);
        Task<List<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(Guid id);
        Task<Role> CreateRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task<Role> DeleteRoleAsync(Guid id);
    }
}

