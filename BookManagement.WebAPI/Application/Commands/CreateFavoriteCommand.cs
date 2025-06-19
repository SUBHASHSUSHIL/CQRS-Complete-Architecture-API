using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class CreateFavoriteCommand : IRequest<Favorite>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public CreateFavoriteCommand(Guid userId, Guid bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}
