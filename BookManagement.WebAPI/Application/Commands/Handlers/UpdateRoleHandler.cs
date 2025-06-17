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
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, Role>
    {
        private readonly IRoleRepository _roleRepository;

        public UpdateRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetRoleByIdAsync(request.Id);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with ID {request.Id} not found.");
            }
            role.RoleName = request.RoleName;
            role.IsDeleted = request.IsDeleted;
            await _roleRepository.UpdateRoleAsync(role);
            return role;
        }
    }
}
