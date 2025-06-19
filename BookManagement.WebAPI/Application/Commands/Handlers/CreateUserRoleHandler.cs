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
    public class CreateUserRoleHandler : IRequestHandler<CreateUserRoleCommand, UserRole>
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public CreateUserRoleHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserRole> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var userRole = new UserRole
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                RoleId = request.RoleId,
                IsDeleted = false
            };
            var createdUserRole = await _userRoleRepository.AddUserRoleAsync(userRole);
            if (createdUserRole == null)
            {
                throw new Exception("Failed to create user role");
            }
            return createdUserRole;
        }
    }
}
