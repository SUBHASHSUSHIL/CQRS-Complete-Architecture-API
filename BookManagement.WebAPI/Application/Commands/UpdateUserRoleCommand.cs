using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class UpdateUserRoleCommand : IRequest<UserRole>, IBaseRequest
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }

        // Constructor to fix CS1729
        public UpdateUserRoleCommand(Guid id, Guid userId, Guid roleId, bool isDeleted)
        {
            Id = id;
            UserId = userId;
            RoleId = roleId;
            IsDeleted = isDeleted;
        }
    }
}
