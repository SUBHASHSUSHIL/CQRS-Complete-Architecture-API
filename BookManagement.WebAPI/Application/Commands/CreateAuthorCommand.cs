using BookManagement.WebAPI.Application.DTOs;
using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class CreateAuthorCommand : IRequest<Author>
    {
        public string AuthorName { get; set; }
        //public bool IsDeleted { get; set; } = false;
        public CreateAuthorCommand(string authorName)
        {
            AuthorName = authorName;
        }
    }
}
