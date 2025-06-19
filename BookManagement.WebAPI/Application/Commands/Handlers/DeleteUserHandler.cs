using BookManagement.WebAPI.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var uery = await _userRepository.GetUserByIdAsync(request.Id);
            if (uery == null)
            {
                throw new Exception("User not found");
            }
            var deletedUser = await _userRepository.DeleteUserAsync(request.Id);
            if (deletedUser == null)
            {
                throw new Exception("User deletion failed");
            }
            return deletedUser.Id;
        }
    }
}
