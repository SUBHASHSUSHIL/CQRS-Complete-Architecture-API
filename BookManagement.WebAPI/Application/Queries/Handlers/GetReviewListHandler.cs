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
    public class GetReviewListHandler : IRequestHandler<GetReviewListQuery, List<Review>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewListHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<Review>> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.GetAllReviewAsync();
        }
    }
}
