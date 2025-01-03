using GrúasUCAB.Core.Usuarios.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Core.Usuarios.Queries;

namespace GrúasUCAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUsuarioRepository _repository;

    public UsuarioController(IMediator mediator, IUsuarioRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }  

    [HttpPost]
    public async Task<IActionResult> CreateUsuario(CreateUsuarioDTO usuarioDto)
    {
        var id = await _mediator.Send(new CreateUsuarioCommand(usuarioDto));
        return CreatedAtAction(nameof(GetUsuario), new { id }, id);
    }

    [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var usuarios = await _mediator.Send(new GetAllUsuariosQuery());
            return Ok(usuarios);
        }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuario(Guid id)
    {
       try
            {
                var usuario = await _repository.GetByIdAsync(id);
                return Ok(usuario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUsuario(Guid id, UpdateUsuarioDTO usuarioDto)
    {
        await _mediator.Send(new UpdateUsuarioCommand(id, usuarioDto));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(Guid id)
    {
        await _mediator.Send(new DeleteUsuarioCommand(id));
        return NoContent();
    }
}

}
