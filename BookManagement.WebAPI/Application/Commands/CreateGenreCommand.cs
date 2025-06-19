using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class CreateGenreCommand : IRequest<Genre>
    {
        public string GenreName { get; set; }
        public CreateGenreCommand(string name)
        {
            GenreName = name;
        }
    }
}
