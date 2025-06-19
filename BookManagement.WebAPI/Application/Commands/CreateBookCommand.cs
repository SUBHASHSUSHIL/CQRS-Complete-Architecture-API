using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishYear { get; set; }
        public Guid AuthorId { get; set; }
        public List<Guid> GenreIds { get; set; }
        public CreateBookCommand(string title, string description, DateTime publishedYear, Guid authorId, List<Guid> genreIds)
        {
            Title = title;
            Description = description;
            PublishYear = publishedYear;
            AuthorId = authorId;
            GenreIds = genreIds;
        }
    }
}
