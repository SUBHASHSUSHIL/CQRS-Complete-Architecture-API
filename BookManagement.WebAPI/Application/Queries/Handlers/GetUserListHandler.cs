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
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUserAsync();
        }
    }
}
