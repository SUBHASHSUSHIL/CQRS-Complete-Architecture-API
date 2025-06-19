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
    public class GetUserBookListHandler : IRequestHandler<GetUserBookListQuery, List<UserBook>>
    {
        private readonly IUserBookRepository _userBookRepository;

        public GetUserBookListHandler(IUserBookRepository userBookRepository)
        {
            _userBookRepository = userBookRepository;
        }

        public async Task<List<UserBook>> Handle(GetUserBookListQuery request, CancellationToken cancellationToken)
        {
            return await _userBookRepository.GetAllUserBookAsync();
        }
    }
}
