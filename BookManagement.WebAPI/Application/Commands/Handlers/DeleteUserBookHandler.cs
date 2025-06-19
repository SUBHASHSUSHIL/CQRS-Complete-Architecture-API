using BookManagement.WebAPI.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands.Handlers
{
    public class DeleteUserBookHandler : IRequestHandler<DeleteUserBookCommand, Guid>
    {
        private readonly IUserBookRepository _userBookRepository;

        public DeleteUserBookHandler(IUserBookRepository userBookRepository)
        {
            _userBookRepository = userBookRepository;
        }

        public async Task<Guid> Handle(DeleteUserBookCommand request, CancellationToken cancellationToken)
        {
            var userBook = await _userBookRepository.GetUserBookByIdAsync(request.Id);
            if (userBook == null)
            {
                throw new KeyNotFoundException($"UserBook with ID {request.Id} not found.");
            }
            var deletedUserBook = await _userBookRepository.DeleteUserBookAsync(request.Id);
            if (deletedUserBook == null)
            {
                throw new Exception("Failed to delete UserBook");
            }
            return deletedUserBook.Id;
        }
    }
}
