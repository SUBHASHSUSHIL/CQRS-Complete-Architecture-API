using BookManagement.WebAPI.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands.Handlers
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, Guid>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Guid> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetRoleByIdAsync(request.Id);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with ID {request.Id} not found");
            }
            var deleteRole = await _roleRepository.DeleteRoleAsync(role.Id);
            return deleteRole.Id;
        }
    }
}
