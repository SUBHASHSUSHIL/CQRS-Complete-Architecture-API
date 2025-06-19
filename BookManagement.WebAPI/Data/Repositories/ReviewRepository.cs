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
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ReviewRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            var newReview = new Review
            {
                Id = Guid.NewGuid(),
                BookId = review.BookId,
                UserId = review.UserId,
                ReviewContent = review.ReviewContent,
                AddedOn = DateTime.Now,
                IsDeleted = review.IsDeleted
            };
            await _applicationDbContext.Reviews.AddAsync(newReview);
            await _applicationDbContext.SaveChangesAsync();
            return newReview;
        }

        public async Task<Review> DeleteReviewAsync(Guid id)
        {
            var review = await _applicationDbContext.Reviews
                .Where(r => r.Id == id && !r.IsDeleted)
                .FirstOrDefaultAsync();
            if (review == null)
            {   
                throw new KeyNotFoundException($"Review with ID {id} not found.");
            }
            review.IsDeleted = true;
            _applicationDbContext.Reviews.Update(review);
            await _applicationDbContext.SaveChangesAsync();
            return review;
        }

        public async Task<List<Review>> GetAllReviewAsync()
        {
            var reviews = await _applicationDbContext.Reviews
                .Where(r => !r.IsDeleted)
                .ToListAsync();
            return reviews;
        }

        public async Task<Review> GetReviewByIdAsync(Guid id)
        {
            var review = await _applicationDbContext.Reviews
                .Where(r => r.Id == id && !r.IsDeleted)
                .FirstOrDefaultAsync();
            return review ?? throw new KeyNotFoundException($"Review with ID {id} not found.");
        }

        public async Task<Review> UpdateReviewAsync(Review review)
        {
            var existingReview = await _applicationDbContext.Reviews
                .Where(r => r.Id == review.Id && !r.IsDeleted)
                .FirstOrDefaultAsync();
            if (existingReview == null)
                {
                throw new KeyNotFoundException($"Review with ID {review.Id} not found.");
            }
            existingReview.BookId = review.BookId;
            existingReview.UserId = review.UserId;
            existingReview.ReviewContent = review.ReviewContent;
            existingReview.AddedOn = review.AddedOn;
            existingReview.IsDeleted = review.IsDeleted;
            _applicationDbContext.Reviews.Update(existingReview);
            await _applicationDbContext.SaveChangesAsync();
            return existingReview;
        }
    }
}
