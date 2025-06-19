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
    public class CreateUserBookHandler : IRequestHandler<CreateUserBookCommand, UserBook>
    {
        private readonly IUserBookRepository _userBookRepository;

        public CreateUserBookHandler(IUserBookRepository userBookRepository)
        {
            _userBookRepository = userBookRepository;
        }

        public async Task<UserBook> Handle(CreateUserBookCommand request, CancellationToken cancellationToken)
        {
            var userBook = new UserBook
            {
                UserId = request.UserId,
                BookId = request.BookId,
                ReservedOn = request.ReservedOn.HasValue ? DateOnly.FromDateTime(request.ReservedOn.Value) : DateOnly.FromDateTime(DateTime.UtcNow),
                ReservedTo = request.ReservedTo.HasValue ? DateOnly.FromDateTime(request.ReservedTo.Value) : DateOnly.FromDateTime(DateTime.UtcNow.AddDays(14))
            };
            var createdUserBook = await _userBookRepository.AddUserBookAsync(userBook);
            if (createdUserBook == null)
            {
                throw new Exception("Failed to create UserBook");
            }
            return createdUserBook;
        }
    }
}
