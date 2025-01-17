using Microsoft.AspNetCore.Mvc;
using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Queries;

[ApiController]
[Route("polizas")]
public class PolizaController : ControllerBase
{
    private readonly IMediator _mediator;

    public PolizaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePolizaDTO dto)
    {
        var id = await _mediator.Send(new CreatePolizaCommand(dto));
        return Ok(new { Id = id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePolizaDTO dto)
    {
        await _mediator.Send(new UpdatePolizaCommand(id, dto));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeletePolizaCommand(id));
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPolizasQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetPolizaByIdQuery(id));
        return Ok(result);
    }

    
}
