using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs
{
    public class FavoriteDto
    {
       
    }

    public class CreateFavoriteDto
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
    }

    public class UpdateFavoriteDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
    }
}
