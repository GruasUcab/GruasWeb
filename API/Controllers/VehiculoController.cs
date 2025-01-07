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
    private readonly IVehiculoRepository _repository;

    public VehiculoController(IMediator mediator, IVehiculoRepository repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehiculo([FromBody] CreateVehiculoDTO vehiculoDto)
    {
        var id = await _mediator.Send(new CreateVehiculoCommand(vehiculoDto));
        return CreatedAtAction(nameof(GetVehiculoByID), new { id }, null);
    }


    [HttpGet]
        public async Task<IActionResult> GetAllVehiculos()
        {
            var vehiculos = await _mediator.Send(new GetAllVehiculosQuery());
            return Ok(vehiculos);
        }

        

   

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehiculoByID(Guid id)
    {
       try
            {
                var vehiculo = await _repository.GetByIdAsync(id);
                return Ok(vehiculo);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
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
