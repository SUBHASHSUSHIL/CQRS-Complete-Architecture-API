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
    public class BookGenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookGenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookGenres()
        {
            var query = new GetBookGenreListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookGenreById(Guid id)
        {
            var query = new GetBookGenreByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookGenre([FromBody] CreateBookGenreDto dto)
        {
            var command = new CreateBookGenreCommand(dto.BookId, dto.GenreId);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookGenreById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookGenre(Guid id, [FromBody] UpdateBookGenreDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }
            var command = new UpdateBookGenreCommand(id, dto.BookId, dto.GenreId, dto.IsDeleted);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"BookGenre with ID {dto.Id} not found.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookGenre(Guid id)
        {
            var command = new DeleteBookGenreCommand(id);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"BookGenre with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
