using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GrúasUCAB.Core.Ordenes.Queries;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Commands;

namespace GrúasUCAB.API.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class OrdenDeServicioController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdenDeServicioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetOrdenDeServicioByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrdenDeServicioDTO ordenDeServicioDTO)
    {
        var command = new CreateOrdenDeServicioCommand(ordenDeServicioDTO);
        var ordenId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = ordenId }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrdenDeServicioDTO ordenDeServicioDTO)
    {
        var command = new UpdateOrdenDeServicioCommand(id, ordenDeServicioDTO);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteOrdenDeServicioCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}

}
