using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GenreRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<Genre> AddGenreAsync(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> DeleteGenreAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Genre>> GetAllGenreAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetGenreByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> UpdateGenreAsync(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
