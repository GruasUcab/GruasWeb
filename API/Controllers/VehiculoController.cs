using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GrúasUCAB.Core.Proveedores.Commands;
using GrúasUCAB.Core.Proveedores.Dto;
using GrúasUCAB.Core.Proveedores.Queries;
using GrúasUCAB.Core.Proveedores.DTO;
namespace GrúasUCAB.API.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class VehiculoController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiculoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehiculo([FromBody] CreateVehiculoDTO vehiculoDto)
    {
        var id = await _mediator.Send(new CreateVehiculoCommand(vehiculoDto));
        return CreatedAtAction(nameof(GetVehiculoById), new { id }, null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehiculoById(Guid id)
    {
        var vehiculo = await _mediator.Send(new GetVehiculoByIdQuery(id));
        return Ok(vehiculo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehiculo(Guid id, [FromBody] UpdateVehiculoDTO vehiculoDto)
    {
        await _mediator.Send(new UpdateVehiculoCommand(id, vehiculoDto));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehiculo(Guid id)
    {
        await _mediator.Send(new DeleteVehiculoCommand(id));
        return NoContent();
    }
}


}
