using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class UpdateGenreCommand : IRequest<Genre>
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public UpdateGenreCommand(Guid id, string name, bool isDeleted)
        {
            Id = id;
            GenreName = name;
        }
    }
}
