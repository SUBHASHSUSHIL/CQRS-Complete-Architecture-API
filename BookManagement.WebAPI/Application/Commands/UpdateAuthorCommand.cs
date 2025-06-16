using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class UpdateAuthorCommand : IRequest<Author>
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public bool IsDeleted { get; set; }
        public UpdateAuthorCommand(Guid id, string authorName, bool isDeleted)
        {
            Id = id;
            AuthorName = authorName;
            IsDeleted = isDeleted;
        }
    }
}
