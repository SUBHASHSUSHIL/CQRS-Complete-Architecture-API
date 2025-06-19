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
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                Phone = request.Phone,
                Photo = request.Photo,
                IsEmailConfirmed = request.IsEmailConfirmed,
                EmailConformationToken = request.EmailConformationToken,
                EmailConfirmationTokenExpiration = request.EmailConfirmationTokenExpiration,
                IsToken = request.IsToken
            };
            var createdUser = await _userRepository.AddUserAsync(user);
            if (createdUser == null)
            {
                throw new Exception("User creation failed");
            }
            return createdUser;
        }
    }
}
