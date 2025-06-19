using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class CreateUserBookCommand : IRequest<UserBook>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime? ReservedOn { get; set; }
        public DateTime? ReservedTo { get; set; }
        public CreateUserBookCommand(Guid userId, Guid bookId, DateTime? reservedOn = null, DateTime? reservedTo = null)
        {
            UserId = userId;
            BookId = bookId;
            ReservedOn = reservedOn ?? DateTime.UtcNow;
            ReservedTo = reservedTo ?? DateTime.UtcNow.AddDays(14);
        }

    } 
}
