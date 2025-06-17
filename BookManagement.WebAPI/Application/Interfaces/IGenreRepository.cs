using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenreAsync();
        Task<Genre> GetGenreByIdAsync(Guid id);
        Task<Genre> AddGenreAsync(Genre genre);
        Task<Genre> UpdateGenreAsync(Genre genre);
        Task<Genre> DeleteGenreAsync(Guid id);
    }
}
