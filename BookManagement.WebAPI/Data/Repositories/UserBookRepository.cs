using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Data.Repositories
{
    public class UserBookRepository : IUserBookRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserBookRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<UserBook> AddUserBookAsync(UserBook userBook)
        {
            throw new NotImplementedException();
        }

        public Task<UserBook> DeleteUserBookAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserBook>> GetAllUserBookAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserBook> GetUserBookByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserBook> UpdateUserBookAsync(UserBook userBook)
        {
            throw new NotImplementedException();
        }
    }
}
