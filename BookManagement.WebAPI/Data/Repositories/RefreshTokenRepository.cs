using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Data.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RefreshTokenRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<RefreshToken> AddRefreshTokenAsync(RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> DeleteRefreshTokenAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RefreshToken>> GetAllRefreshTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> GetRefreshTokenByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
