using BookManagement.WebAPI.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands.Handlers
{
    public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand, Guid>
    {
        private readonly IReviewRepository _reviewRepository;

        public DeleteReviewHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Guid> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetReviewByIdAsync(request.Id);
            if (review == null)
            {
                throw new KeyNotFoundException($"Review with ID {request.Id} not found.");
            }
            var deletedReview = await _reviewRepository.DeleteReviewAsync(request.Id);
            if (deletedReview == null)
            {
                throw new Exception("Failed to delete the review.");
            }
            return deletedReview.Id;
        }
    }
}
