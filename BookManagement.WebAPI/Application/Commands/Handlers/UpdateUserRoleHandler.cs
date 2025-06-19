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
    public class UpdateUserRoleHandler : IRequestHandler<UpdateUserRoleCommand, UserRole>
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UpdateUserRoleHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserRole> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var userRole = await _userRoleRepository.GetUserRoleByIdAsync(request.Id);
            if (userRole == null)
            {
                throw new Exception("User role not found");
            }
            userRole.RoleId = request.RoleId;
            userRole.UserId = request.UserId;
            var updatedUserRole = await _userRoleRepository.UpdateUserRoleAsync(userRole);
            if (updatedUserRole == null)
            {
                throw new Exception("Failed to update user role");
            }
            return updatedUserRole;
        }
    }
}
