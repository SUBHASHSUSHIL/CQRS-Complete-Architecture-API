using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class CreateReviewCommand : IRequest<Review>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string ReviewContent { get; set; }
        public int Rating { get; set; }
        public CreateReviewCommand(Guid userId, Guid bookId, string reviewContent, int rating)
        {
            UserId = userId;
            BookId = bookId;
            ReviewContent = reviewContent;
            Rating = rating;
        }
    }
}
