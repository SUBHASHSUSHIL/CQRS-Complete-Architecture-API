using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Authentication.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> FindByEmailAsync(string email);
        Task<User?> FindByNameAsync(string userName);
        Task<User?> FindByPhoneAsync(string phone);
        Task<string?> AddToRoleAsync(Guid userId, string role);
    }
}
