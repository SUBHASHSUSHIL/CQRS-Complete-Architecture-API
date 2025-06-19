using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Queries.Handlers
{
    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, Review>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByIdHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.GetReviewByIdAsync(request.Id);
        }
    }
}
