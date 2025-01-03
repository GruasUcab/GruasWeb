using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Queries;
using GrúasUCAB.Core.Proveedores.Dto;
using GrúasUCAB.Core.Proveedores.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace GrúasUCAB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
public class ConductorController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConductorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateConductor([FromBody] CreateConductorDTO conductorDto)
    {
        var id = await _mediator.Send(new CreateConductorCommand(conductorDto));
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateConductor(Guid id, [FromBody] UpdateConductorDTO conductorDto)
    {
        conductorDto.Id = id;
        await _mediator.Send(new UpdateConductorCommand(conductorDto));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConductor(Guid id)
    {
        await _mediator.Send(new DeleteConductorCommand(id));
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllConductores()
    {
        var conductores = await _mediator.Send(new GetAllConductoresQuery());
        return Ok(conductores);
    }
}

}
