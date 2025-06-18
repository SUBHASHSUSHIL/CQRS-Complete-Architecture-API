using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Interfaces
{
    public interface IUserBookRepository
    {
        Task<List<UserBook>> GetAllUserBookAsync();
        Task<UserBook> GetUserBookByIdAsync(Guid id);
        Task<UserBook> AddUserBookAsync(UserBook userBook);
        Task<UserBook> UpdateUserBookAsync(UserBook userBook);
        Task<UserBook> DeleteUserBookAsync(Guid id);
    }
}
