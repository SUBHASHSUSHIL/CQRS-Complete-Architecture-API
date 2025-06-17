using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RoleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            var roles = new Role
            {
                Id = Guid.NewGuid(),
                RoleName = role.RoleName,
                IsDeleted = role.IsDeleted
            };
            await _applicationDbContext.Roles.AddAsync(roles);
            await _applicationDbContext.SaveChangesAsync();
            return roles;
        }

        public async Task<Role> DeleteRoleAsync(Guid id)
        {
            var role = await _applicationDbContext.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (role ==  null)
            {
                return null;
            }
            role.IsDeleted = true;
            _applicationDbContext.Roles.Update(role);
            await _applicationDbContext.SaveChangesAsync();
            return role;
            
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            var role = await _applicationDbContext.Roles.ToListAsync();
            return role;
        }

        public async Task<Role> GetRoleByIdAsync(Guid id)
        {
            var role = await _applicationDbContext.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();
            return role ?? throw new NotImplementedException();
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            var filterData = await _applicationDbContext.Roles.FindAsync(role.Id);
            if (filterData == null)
            {
                return null;
            }
            filterData.RoleName = role.RoleName;
            filterData.IsDeleted = role.IsDeleted;
            _applicationDbContext.Roles.Update(filterData);
            await _applicationDbContext.SaveChangesAsync();
            return filterData;
        }
    }
}
