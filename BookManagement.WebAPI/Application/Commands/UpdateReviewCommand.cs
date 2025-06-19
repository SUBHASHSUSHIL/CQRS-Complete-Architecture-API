using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class UpdateReviewCommand : IRequest<Review>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string ReviewContent { get; set; }
        public UpdateReviewCommand(Guid id, Guid userId, Guid bookId, string reviewContent, bool isDeleted)
        {
            Id = id;
            UserId = userId;
            BookId = bookId;
            ReviewContent = reviewContent;
        }
    }
}
