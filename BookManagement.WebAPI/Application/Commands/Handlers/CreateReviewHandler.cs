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
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, Review>
    {
        private readonly IReviewRepository _reviewRepository;

        public CreateReviewHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                UserId = request.UserId,
                BookId = request.BookId,
                ReviewContent = request.ReviewContent
            };
            var createdReview = await _reviewRepository.AddReviewAsync(review);
            return createdReview;
        }
    }
}
