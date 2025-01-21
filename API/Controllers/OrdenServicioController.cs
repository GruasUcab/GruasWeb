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
    private readonly IOrdenDeServicioRepository _repository;
    private readonly EstadoOrdenMachine _estadoOrdenMachine;

    public OrdenDeServicioController(IMediator mediator, IOrdenDeServicioRepository repository, EstadoOrdenMachine estadoOrdenMachine)
    {
        _mediator = mediator;
        _repository =repository;
        _estadoOrdenMachine = estadoOrdenMachine;
    }

    /*[HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetOrdenDeServicioByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }*/

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
       try
            {
                var ordenDeServicio = await _repository.GetByIdAsync(id);
                return Ok(ordenDeServicio);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrdenDeServicioDTO ordenDeServicioDTO)
    {
        var command = new CreateOrdenDeServicioCommand(ordenDeServicioDTO);
        var ordenId = await _mediator.Send(command);
            //return CreatedAtAction(nameof(GetById), new { id = ordenId }, null);
            return Ok(new { id = ordenId });
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

     [HttpPost("asignar")]
    public async Task<IActionResult> AsignarConductorYProveedor([FromBody] AsignarConductorProveedorDTO dto)
    {
        try
        {
            await _estadoOrdenMachine.AsignarConductorYProveedor(dto.OrdenId, dto.ConductorId, dto.ProveedorId, dto.UbicacionConductor);
            return Ok("Conductor y Proveedor asignados con éxito.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("finalizar/{id}")]
    public async Task<IActionResult> FinalizarOrden(Guid id)
    {
        try
        {
            await _estadoOrdenMachine.FinalizarOrden(id);
            return Ok("Orden finalizada con éxito.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("cancelar/{id}")]
    public async Task<IActionResult> CancelarOrden(Guid id)
    {
        try
        {
            await _estadoOrdenMachine.CancelarOrden(id);
            return Ok("Orden cancelada con éxito.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{conductorId:guid}/ordenes")]
    public async Task<IActionResult> GetOrdenesByConductorId(Guid conductorId)
    {
        var ordenes = await _mediator.Send(new GetOrdenesByConductorIdQuery(conductorId));
        return Ok(ordenes);
    }
}

}