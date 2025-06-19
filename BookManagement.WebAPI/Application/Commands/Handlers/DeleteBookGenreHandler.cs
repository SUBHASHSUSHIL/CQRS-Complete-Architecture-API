using BookManagement.WebAPI.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands.Handlers
{
    public class DeleteBookGenreHandler : IRequestHandler<DeleteBookGenreCommand, Guid>
    {
        private readonly IBookGenreRepository _bookGenreRepository;

        public DeleteBookGenreHandler(IBookGenreRepository bookGenreRepository)
        {
            _bookGenreRepository = bookGenreRepository;
        }

        public async Task<Guid> Handle(DeleteBookGenreCommand request, CancellationToken cancellationToken)
        {
            var bookGenre = await _bookGenreRepository.GetBookGenreById(request.Id);
            if (bookGenre == null)
            {
                throw new KeyNotFoundException($"BookGenre with ID {request.Id} not found.");
            }
            var deletedBookGenre = await _bookGenreRepository.DeleteBookGenreById(request.Id);
            if (deletedBookGenre == null)
            {
                throw new Exception("Failed to delete book genre");
            }
            return deletedBookGenre.Id;
        }
    }
}
