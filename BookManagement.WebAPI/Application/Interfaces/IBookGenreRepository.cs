using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Interfaces
{
    public interface IBookGenreRepository
    {
        Task<List<BookGenre>> GetBookGenreAll();
        Task<BookGenre> GetBookGenreById(Guid id);
        Task<BookGenre>CreateBookGenre(BookGenre bookGenre);
        Task<BookGenre> UpdateBookGenre(BookGenre bookGenre);
        Task<BookGenre> DeleteBookGenreById(Guid id);
    }
}
