using BookManagement.WebAPI.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands.Handlers
{
    public class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand, Guid>
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public DeleteUserRoleHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<Guid> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            var userRole = await _userRoleRepository.GetUserRoleByIdAsync(request.Id);
            if (userRole == null)
            {
                throw new Exception("User role not found");
            }
            userRole.IsDeleted = true;
            var deletedUserRole = await _userRoleRepository.DeleteUserRoleAsync(request.Id);
            if (deletedUserRole == null)
            {
                throw new Exception("Failed to delete user role");
            }
            return deletedUserRole.Id; // Return the ID of the deleted user role
        }
    }
}
