using BookManagement.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs
{
    public class GenreDto
    {
    
    }

    public class CreateGenreDto
    {
        public string GenreName { get; set; }
    }

    public class UpdateGenreDto
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
