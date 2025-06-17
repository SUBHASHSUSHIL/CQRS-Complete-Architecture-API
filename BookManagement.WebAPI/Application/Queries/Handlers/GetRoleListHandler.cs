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
    public class GetRoleListHandler : IRequestHandler<GetRoleListQuery, List<Role>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleListHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<Role>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetAllRolesAsync();
        }
    }
}
