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
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var query = new GetGenreListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(Guid id)
        {
            var query = new GetGenreByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDto dto)
        {
            var command = new CreateGenreCommand(dto.GenreName);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetGenreById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(Guid id, [FromBody] UpdateGenreDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }
            var command = new UpdateGenreCommand(dto.Id, dto.GenreName, dto.IsDeleted);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"Genre with ID {dto.Id} not found.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            var command = new DeleteGenreCommand(id);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"Genre with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
