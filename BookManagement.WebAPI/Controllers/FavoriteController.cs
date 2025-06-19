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
    public class FavoriteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoriteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFavorites()
        {
            var query = new GetFavoriteListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavoriteById(Guid id)
        {
            var query = new GetFavoriteByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFavorite([FromBody] CreateFavoriteDto dto)
        {
            var command = new CreateFavoriteCommand(dto.UserId, dto.BookId);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetFavoriteById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFavorite(Guid id, [FromBody] UpdateFavoriteDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }
            var command = new UpdateFavoriteCommand(dto.Id, dto.UserId, dto.BookId, dto.IsDeleted);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"Favorite with ID {dto.Id} not found.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(Guid id)
        {
            var command = new DeleteFavoriteCommand(id);
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"Favorite with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
