using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Authentication.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IBaseRepository<PenddingUser> PenddingUsers { get; }
        IRoleRepository Roles { get; }
        IBaseRepository<RefreshToken> RefreshTokens { get; }
        IBaseRepository<BlacklistedToken> blacklistedTokens { get; }
    }
}
