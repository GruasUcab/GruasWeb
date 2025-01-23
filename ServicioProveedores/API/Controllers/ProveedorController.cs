using GrúasUCAB.Core.Proveedores.Commands;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GrúasUCAB.Core.Proveedores.Queries;

namespace GrúasUCAB.API.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class ProveedorController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProveedorRepository _repository;

    public ProveedorController(IMediator mediator, IProveedorRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }   

    [HttpPost]
    public async Task<IActionResult> CreateProveedor(CreateProveedorDTO proveedorDTO)
    {
        var id = await _mediator.Send(new CreateProveedorCommand(proveedorDTO));
        return CreatedAtAction(nameof(GetProveedor), new { id }, id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProveedor(Guid id)
    {
       try
            {
                var proveedor = await _repository.GetByIdAsync(id);
                return Ok(proveedor);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
    }


    [HttpGet]
    public async Task<IActionResult> GetAllProveedores()
    {
        var proveedores = await _mediator.Send(new GetAllProveedoresQuery()); // Implementar QueryHandler
        return Ok(proveedores);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProveedor(UpdateProveedorDTO proveedorDto)
    {
        await _mediator.Send(new UpdateProveedorCommand(proveedorDto));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProveedor(Guid id)
    {
        await _mediator.Send(new DeleteProveedorCommand(id));
        return NoContent();
    }
}

}
