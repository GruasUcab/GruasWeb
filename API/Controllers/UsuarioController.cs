using MediatR;
using Microsoft.AspNetCore.Mvc;
using GrúasUCAB.Core.Usuarios.Queries;
using GrúasUCAB.Core.Usuarios.Commands;

namespace GrúasUCAB.API.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUsuarioCommand command)
    {
        var userId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = userId }, null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var usuario = await _mediator.Send(new GetUsuarioByIdQuery { Id = id });
        return usuario == null ? NotFound() : Ok(usuario);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _mediator.Send(new GetAllUsuariosQuery());
        return Ok(usuarios);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUsuarioCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteUsuarioCommand { Id = id });
        return NoContent();
    }
}

 



}
