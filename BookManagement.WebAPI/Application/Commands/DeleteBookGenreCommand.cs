using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class DeleteBookGenreCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public DeleteBookGenreCommand(Guid id)
        {
            Id = id;
        }
    }
}
