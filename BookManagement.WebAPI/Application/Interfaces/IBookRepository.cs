using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBookAllAsync();
        Task<Book> GetBookByIdAsync(Guid id);
        Task<Book> AddBookAsync(Book book);
        Task DeleteBookAsync(Guid id);
        Task<Book> UpdateBookAsync(Book book);
    }
}
