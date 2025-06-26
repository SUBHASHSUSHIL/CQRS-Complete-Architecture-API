using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Authentication.Interfaces;
using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public Authentication.Interfaces.IUserRepository Users => throw new NotImplementedException();

        public IBaseRepository<PenddingUser> PenddingUsers => throw new NotImplementedException();

        public IRoleRepository Roles => throw new NotImplementedException();

        public IBaseRepository<RefreshToken> RefreshTokens => throw new NotImplementedException();

        public IBaseRepository<BlacklistedToken> blacklistedTokens => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
