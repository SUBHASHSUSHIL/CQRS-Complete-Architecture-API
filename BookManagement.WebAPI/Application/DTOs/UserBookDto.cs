using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs
{
    public class UserBookDto
    {
       
    }

    public class CreateUserBookDto
    {
        public DateOnly ReservedOn = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly ReservedTo { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class UpdateUserBookDto
    {
        public Guid Id { get; set; }
        public DateOnly ReservedOn = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly ReservedTo { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
