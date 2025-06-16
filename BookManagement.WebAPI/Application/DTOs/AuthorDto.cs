using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Application.DTOs
{
    public class AuthorDto
    {

    }

    public class CreateAuthorDto
    {
        public string AuthorName { get; set; }
    }

    public class UpdateAuthorDto
    {
        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
