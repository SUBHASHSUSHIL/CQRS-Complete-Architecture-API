using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ReviewRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<Review> AddReviewAsync(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<Review> DeleteReviewAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetAllReviewAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetReviewByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Review> UpdateReviewAsync(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
