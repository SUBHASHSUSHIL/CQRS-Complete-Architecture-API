using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands.Handlers
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, Role>
    {
        private readonly IRoleRepository _roleRepository; 

        public CreateRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),
                RoleName = request.RoleName,
                IsDeleted = false
            };
            return await _roleRepository.CreateRoleAsync(role);
        }
    }
}
