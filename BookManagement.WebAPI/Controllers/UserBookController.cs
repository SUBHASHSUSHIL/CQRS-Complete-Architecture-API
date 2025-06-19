using BookManagement.WebAPI.Application.Commands;
using BookManagement.WebAPI.Application.DTOs;
using BookManagement.WebAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserBookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserBooks()
        {
            var query = new GetUserBookListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserBookById(Guid id)
        {
            var query = new GetUserBookByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserBook([FromBody] CreateUserBookDto dto)
        {
            var command = new CreateUserBookCommand(dto.UserId, dto.BookId);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserBookById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserBook(Guid id, [FromBody] UpdateUserBookDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }
            var command = new UpdateUserBookCommand(dto.Id, dto.UserId, dto.BookId);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"UserBook with ID {dto.Id} not found.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserBook(Guid id)
        {
            var command = new DeleteUserBookCommand(id);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"UserBook with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
