using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllReviewAsync();
        Task<Review> GetReviewByIdAsync(Guid id);
        Task<Review> AddReviewAsync(Review review);
        Task<Review> UpdateReviewAsync(Review review);
        Task<Review> DeleteReviewAsync(Guid id);
    }
}
