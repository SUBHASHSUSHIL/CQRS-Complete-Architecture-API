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
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = request.Id,
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
            var updatedUser = await _userRepository.UpdateUserAsync(user);
            if (updatedUser == null)
            {
                throw new Exception("User update failed");
            }
            return updatedUser;
        }
    }
}
