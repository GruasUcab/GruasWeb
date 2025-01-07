using Microsoft.AspNetCore.Mvc;
using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Queries;

[Route("api/[controller]")]
[ApiController]
public class CostoAdicionalController : ControllerBase
{
    private readonly IMediator _mediator;

    public CostoAdicionalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCostoAdicionalCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var costoAdicional = await _mediator.Send(new GetCostoAdicionalByIdQuery(id));
        if (costoAdicional == null)
        {
            return NotFound();
        }

        return Ok(costoAdicional);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCostoAdicionalCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("El ID del costo adicional no coincide.");
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteCostoAdicionalCommand(id));
        return NoContent();
    }
}
