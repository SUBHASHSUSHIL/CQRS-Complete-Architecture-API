using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> GetAllFavoriteAsync();
        Task<Favorite> GetFavoriteByIdAsync(Guid id);
        Task<Favorite> AddAsync(Favorite favorite);
        Task<Favorite> UpdateAsync(Favorite favorite);
        Task<Favorite> DeleteAsync(Guid id);
    }
}
