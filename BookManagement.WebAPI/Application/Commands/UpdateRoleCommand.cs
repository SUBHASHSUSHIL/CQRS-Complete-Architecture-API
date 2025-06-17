using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class UpdateRoleCommand : IRequest<Role>
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; }

        public UpdateRoleCommand(Guid id, string roleName, bool isDeleted)
        {
            Id = id;
            RoleName = roleName;
            IsDeleted = isDeleted;
        }
    }
}
