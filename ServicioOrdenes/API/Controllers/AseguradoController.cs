using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrúasUCAB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AseguradoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AseguradoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAseguradoDTO dto)
        {
            var id = await _mediator.Send(new CreateAseguradoCommand { AseguradoDto = dto });
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var asegurado = await _mediator.Send(new GetAseguradoByIdQuery { Id = id });
            return Ok(asegurado);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var asegurados = await _mediator.Send(new GetAllAseguradosQuery());
            return Ok(asegurados);
        }

       
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAseguradoDTO dto)
        {
            await _mediator.Send(new UpdateAseguradoCommand { Id = id, AseguradoDto = dto });
            return NoContent();
        }

        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteAseguradoCommand { Id = id });
            return NoContent();
        }
    }
}
