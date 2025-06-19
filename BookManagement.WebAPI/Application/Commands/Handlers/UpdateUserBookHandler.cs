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
    public class UpdateUserBookHandler : IRequestHandler<UpdateUserBookCommand, UserBook>
    {
        private readonly IUserBookRepository _userBookRepository;

        public UpdateUserBookHandler(IUserBookRepository userBookRepository)
        {
            _userBookRepository = userBookRepository;
        }

        public async Task<UserBook> Handle(UpdateUserBookCommand request, CancellationToken cancellationToken)
        {
            var userBook = await _userBookRepository.GetUserBookByIdAsync(request.Id);
            if (userBook == null)
            {
                throw new KeyNotFoundException($"UserBook with ID {request.Id} not found.");
            }
            userBook.UserId = request.UserId;
            userBook.BookId = request.BookId;
            var usersbook = await _userBookRepository.UpdateUserBookAsync(userBook);
            return usersbook ?? throw new Exception("Failed to update UserBook");

        }
    }
}
