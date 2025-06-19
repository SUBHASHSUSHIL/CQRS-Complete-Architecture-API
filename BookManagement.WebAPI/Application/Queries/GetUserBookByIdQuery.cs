using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Queries
{
    public class GetUserBookByIdQuery : IRequest<UserBook>
    {
        public Guid Id { get; set; }
    }
}
