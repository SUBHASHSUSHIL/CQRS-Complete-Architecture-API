using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs
{
    public class ReviewDto
    {
        
    }

    public class CreateReviewDto
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string ReviewContent { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; } = null;
        public bool IsDeleted { get; set; }
    }

    public class UpdateReviewDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string ReviewContent { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; } = null;
        public bool IsDeleted { get; set; }
    }
}
