using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Data.Repositories
{
    public class BookGenreRepository : IBookGenreRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookGenreRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<BookGenre> CreateBookGenre(BookGenre bookGenre)
        {
            throw new NotImplementedException();
        }

        public Task<BookGenre> DeleteBookGenreById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookGenre>> GetBookGenreAll()
        {
            throw new NotImplementedException();
        }

        public Task<BookGenre> GetBookGenreById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BookGenre> UpdateBookGenre(BookGenre bookGenre)
        {
            throw new NotImplementedException();
        }
    }
}
