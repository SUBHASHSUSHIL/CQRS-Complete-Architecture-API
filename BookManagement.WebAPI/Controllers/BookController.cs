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
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var query = new GetUserRoleListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var query = new GetUserRoleByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateUserRoleDto dto)
        {
            var command = new CreateUserRoleCommand(dto.UserId, dto.RoleId);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateUserRoleDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }
            var command = new UpdateUserRoleCommand(dto.Id, dto.UserId, dto.RoleId, dto.IsDeleted);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"UserRole with ID {dto.Id} not found.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var command = new DeleteUserRoleCommand(id);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"UserRole with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
