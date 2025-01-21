using MediatR;
using Microsoft.AspNetCore.Mvc;
using GrúasUCAB.Core.Usuarios.Queries;
using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Dto;

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

    [HttpPost("Proveedor")]
    public async Task<IActionResult> CreateProveedor([FromBody] CreateUsuarioProveedorCommand command)
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

    /*[HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUsuarioCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }*/
    [HttpPut]
    public async Task<IActionResult> UpdateUsuarioCommand(UpdateUsuarioDTO usuariodto)
    {
        await _mediator.Send(new UpdateUsuarioCommand(usuariodto));
        return NoContent();
    }

    [HttpPut("Proveedor")]
    public async Task<IActionResult> UpdateUsuarioProveedorCommand(UpdateUsuarioProveedorDTO usuariodto)
    {
        await _mediator.Send(new UpdateUsuarioProveedorCommand(usuariodto));
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteUsuarioCommand { Id = id });
        return NoContent();
    }

    [HttpGet("proveedores")]
public async Task<IActionResult> GetUsuariosProveedores()
{
    var usuariosProveedores = await _mediator.Send(new GetAllUsuariosProveedoresQuery());
    return Ok(usuariosProveedores);
}

    [HttpGet("usuario/id-by-sub/{sub}")]
public async Task<IActionResult> GetUsuarioIdBySub(string sub)
{
    var usuarioId = await _mediator.Send(new GetUsuarioIdBySubQuery(sub));
    if (usuarioId == null)
    {
        return NotFound(new { Message = "Usuario no encontrado" });
    }

    return Ok(new { UsuarioId = usuarioId });
}
 
 [HttpGet("usuario/provedorbyid/{sub}")]
public async Task<IActionResult> GetProveedorIdBySub(string sub)
{
    var proveeId = await _mediator.Send(new GetProveedorIdBySubQuery(sub));
    if (proveeId == null)
    {
        return NotFound(new { Message = "Usuario no encontrado" });
    }

    return Ok(new { ProveeId = proveeId });
}



}}
