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
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Role>> GetAllRoleAsync()
        {
            var role = new GetRoleListQuery();
            return await _mediator.Send(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto dto)
        {
            var command = new CreateRoleCommand(dto.RoleName);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRoleById), new { id = result.Id }, result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            var role = await _mediator.Send(new GetRoleByIdQuery { Id = id });
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto dto)
        {
            var command = new UpdateRoleCommand(dto.Id, dto.RoleName, dto.IsDeleted);
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NotFound($"Role with ID {dto.Id} not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var command = new DeleteRoleCommand(id);
            var result = await _mediator.Send(command);
            if(result == Guid.Empty)
            {
                return NotFound($"Role with ID {id} not found");
            }
            return Ok($"Role with ID {id} deleted successfully.");
        }

    }
}
