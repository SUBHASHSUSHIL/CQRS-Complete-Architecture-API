using BookManagement.WebAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.Commands
{
    public class UpdateBookCommand : IRequest<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Isbn { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
        public List<Guid> AuthorIds { get; set; }
        public List<Guid> GenreIds { get; set; }
        public UpdateBookCommand(Guid id, string title, string description, DateTime publishedDate, string isbn, int pageCount, string language, List<Guid> authorIds, List<Guid> genreIds)
        {
            Id = id;
            Title = title;
            Description = description;
            PublishedDate = publishedDate;
            Isbn = isbn;
            PageCount = pageCount;
            Language = language;
            AuthorIds = authorIds;
            GenreIds = genreIds;
        }
    }
}
