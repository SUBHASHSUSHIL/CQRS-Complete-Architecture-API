using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class DeleteAuthorCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public DeleteAuthorCommand(Guid id)
        {
            Id = id;
        }
    }
}
