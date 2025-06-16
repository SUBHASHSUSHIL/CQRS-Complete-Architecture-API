using BookManagement.WebAPI.Application.Commands;
using BookManagement.WebAPI.Application.DTOs;
using BookManagement.WebAPI.Application.Queries;
using BookManagement.WebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Author>> GetAuthorList()
        {
            var query = new GetAuthorListQuery();
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<Author> GetAuthorById(Guid id)
        {
            var query = await _mediator.Send(new GetAuthorByIdQuery() { Id = id });
            return query;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDto dto)
        {
            var command = new UpdateAuthorCommand(dto.Id, dto.AuthorName, dto.IsDeleted);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"Author with ID {dto.Id} not found.");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto dto)
        {
            var command = new CreateAuthorCommand(dto.AuthorName);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAuthorById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var command = new DeleteAuthorCommand(id);
            var result = await _mediator.Send(command);
            if (result == Guid.Empty)
            {
                return NotFound($"Author with ID {id} not found.");
            }
            return Ok($"Author with ID {id} deleted successfully.");
        }
    }
}