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
    public class GetUserBookByIdHandler : IRequestHandler<GetUserBookByIdQuery, UserBook>
    {
        private readonly IUserBookRepository _userBookRepository;

        public GetUserBookByIdHandler(IUserBookRepository userBookRepository)
        {
            _userBookRepository = userBookRepository;
        }

        public async Task<UserBook> Handle(GetUserBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userBookRepository.GetUserBookByIdAsync(request.Id);
        }
    }
}
