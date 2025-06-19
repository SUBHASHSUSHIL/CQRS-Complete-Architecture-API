using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands.Handlers
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, Review>
    {
        private readonly IReviewRepository _reviewRepository;

        public UpdateReviewHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var existingReview = await _reviewRepository.GetReviewByIdAsync(request.Id);
            if (existingReview == null)
            {
                throw new KeyNotFoundException($"Review with ID {request.Id} not found.");
            }
            existingReview.UserId = request.UserId;
            existingReview.BookId = request.BookId;
            existingReview.ReviewContent = request.ReviewContent;
            var updatedReview = await _reviewRepository.UpdateReviewAsync(existingReview);
            if (updatedReview == null)
            {
                throw new Exception("Failed to update the review.");
            }
            return updatedReview;
        }
    }
}
