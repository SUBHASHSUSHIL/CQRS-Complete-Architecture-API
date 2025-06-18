using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<List<RefreshToken>> GetAllRefreshTokenAsync();
        Task<RefreshToken> GetRefreshTokenByIdAsync(Guid id);
        Task<RefreshToken> AddRefreshTokenAsync(RefreshToken refreshToken);
        Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken);
        Task<RefreshToken> DeleteRefreshTokenAsync(Guid id);
    }
}
