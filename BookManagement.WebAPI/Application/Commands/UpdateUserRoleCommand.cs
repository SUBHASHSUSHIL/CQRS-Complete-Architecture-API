using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class UpdateUserRoleCommand : IRequest<UserRole>
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public UpdateUserRoleCommand(Guid id, Guid roleId, Guid userId)
        {
            Id = id;
            RoleId = roleId;
            UserId = userId;
        }
    }
}
