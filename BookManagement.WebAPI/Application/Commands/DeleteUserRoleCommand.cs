using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class DeleteUserRoleCommand : IRequest<Guid>
    { 
        public Guid Id { get; set; }
        public DeleteUserRoleCommand(Guid id)
        {
            Id = id;
        }
    }
}
