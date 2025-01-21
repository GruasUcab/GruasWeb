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
    private readonly IConductorRepository _repository;

    public ConductorController(IMediator mediator, IConductorRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    /*[HttpPost]
    public async Task<IActionResult> CreateConductor([FromBody] CreateConductorDTO conductorDto)
    {
        var id = await _mediator.Send(new CreateConductorCommand(conductorDto));
        return Ok(id);
    }*/

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateConductorCommand command)
    {
        var userId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetConductor), new { id = userId }, null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetConductor(Guid id)
    {
       try
            {
                var conductor = await _repository.GetByIdAsync(id);
                return Ok(conductor);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateConductor(UpdateConductorDTO conductorDto)
    {
        
        await _mediator.Send(new UpdateConductorCommand(conductorDto));
        return NoContent();
    }

    [HttpPut("UpdateUbicacion{id}")]
    public async Task<IActionResult> UpdateConductorUbicacion(Guid id, UpdateConductorUbicacionDTO conductorDto)
    {
        
        await _mediator.Send(new UpdateConductorUbicacionCommand(id,conductorDto));
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

    [HttpGet("conductor/id-by-sub/{sub}")]
public async Task<IActionResult> GetConductorIdBySub(string sub)
{
    var conductorId = await _mediator.Send(new GetConductorIdBySubQuery(sub));
    if (conductorId == null)
    {
        return NotFound(new { Message = "Conductor no encontrado" });
    }

    return Ok(new { ConductorId = conductorId });
}
}

}
