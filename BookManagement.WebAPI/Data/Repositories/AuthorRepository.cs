using BookManagement.WebAPI.Application.DTOs;
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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthorRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            var newAuthor = new Author
            {
                Id = Guid.NewGuid(),
                AuthorName = author.AuthorName,
                IsDeleted = author.IsDeleted
            };

            await _applicationDbContext.Authors.AddAsync(newAuthor);
            await _applicationDbContext.SaveChangesAsync();
            return newAuthor;
        }

        public async Task<Author> DeleteAuthorAsync(Guid id)
        {
            var filterData = await _applicationDbContext.Authors.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (filterData == null)
            {
                return null; // or throw an exception if preferred
            }
            filterData.IsDeleted = true; // Mark as deleted instead of removing from DB
            _applicationDbContext.Authors.Update(filterData);
            await _applicationDbContext.SaveChangesAsync();
            return filterData;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            var authors = await _applicationDbContext.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author> GetAuthorByIdAsync(Guid id)
        {
            var filterData = await _applicationDbContext.Authors.Where(x => x.Id == id).FirstOrDefaultAsync();
            return filterData;
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            var existingAuthor = await _applicationDbContext.Authors.FindAsync(author.Id);
            if (existingAuthor == null)
            {
                return null; // or throw an exception if preferred
            }
            existingAuthor.AuthorName = author.AuthorName;
            existingAuthor.IsDeleted = author.IsDeleted;
            _applicationDbContext.Authors.Update(existingAuthor);
            await _applicationDbContext.SaveChangesAsync();
            return existingAuthor;
        }
    }
}
