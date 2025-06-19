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

        //public async Task<RefreshToken> DeleteRefreshTokenAsync(Guid id)
        //{
        //    var refreshToken = await _applicationDbContext.RefreshTokens
        //        .Where(rt => rt.Id == id)
        //        .FirstOrDefaultAsync();
        //    if (refreshToken == null)
        //        {
        //        throw new KeyNotFoundException($"Refresh token with ID {id} not found.");
        //    }
        //    refreshToken.IsDeleted = true;
        //    _applicationDbContext.RefreshTokens.Update(refreshToken);
        //    await _applicationDbContext.SaveChangesAsync();
        //    return refreshToken;
        //}

        public async Task<List<RefreshToken>> GetAllRefreshTokenAsync()
        {
            var refreshTokens = await _applicationDbContext.RefreshTokens.ToListAsync();
            return refreshTokens;
        }

        public async Task<RefreshToken> GetRefreshTokenByIdAsync(Guid id)
        {
            var refreshToken = await _applicationDbContext.RefreshTokens
                .Where(rt => rt.Id == id)
                .FirstOrDefaultAsync();
            return refreshToken ?? throw new KeyNotFoundException($"Refresh token with ID {id} not found.");
        }

        public Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
