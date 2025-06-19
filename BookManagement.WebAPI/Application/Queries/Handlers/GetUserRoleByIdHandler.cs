using BookManagement.WebAPI.Application.Interfaces;
using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Queries.Handlers
{
    public class GetUserRoleByIdHandler : IRequestHandler<GetUserRoleByIdQuery, UserRole>
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public GetUserRoleByIdHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserRole> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRoleRepository.GetUserRoleByIdAsync(request.Id);
        }
    }
}
