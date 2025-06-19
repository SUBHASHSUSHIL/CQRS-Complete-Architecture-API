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
    public class GetUserRoleListHandler : IRequestHandler<GetUserRoleListQuery, List<UserRole>>
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public GetUserRoleListHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<List<UserRole>> Handle(GetUserRoleListQuery request, CancellationToken cancellationToken)
        {
            return await _userRoleRepository.GetAllUserRoleAsync();
        }
    }
}
