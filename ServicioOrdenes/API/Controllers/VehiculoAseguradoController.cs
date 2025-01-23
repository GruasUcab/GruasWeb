using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrúasUCAB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoAseguradoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehiculoAseguradoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehiculoAseguradoDTO dto)
        {
             var id = await _mediator.Send(new CreateVehiculoAseguradoCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        

        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var vehiculoAsegurado = await _mediator.Send(new GetVehiculoAseguradoByIdQuery { Id = id });
            return Ok(vehiculoAsegurado);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehiculosasegurados = await _mediator.Send(new GetAllVehiculosAseguradosQuery());
            return Ok(vehiculosasegurados);
        }

       
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVehiculoAseguradoDTO dto)
        {
    
            await _mediator.Send(new UpdateVehiculoAseguradoCommand(id, dto));

            return NoContent();
        }


        
        /*[HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteAseguradoCommand { Id = id });
            return NoContent();
        }*/
    }
}
