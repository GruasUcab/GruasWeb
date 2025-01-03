using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Dto;
using GrúasUCAB.Core.Usuarios.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrúasUCAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartamentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartamentos()
        {
            var departamentos = await _mediator.Send(new GetAllDepartamentosQuery());
            return Ok(departamentos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartamento([FromBody] CreateDepartamentoDto dto)
        {
            var id = await _mediator.Send(new CreateDepartamentoCommand(dto));
            return CreatedAtAction(nameof(GetAllDepartamentos), new { id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartamento([FromBody] UpdateDepartamentoDto dto)
        {
            await _mediator.Send(new UpdateDepartamentoCommand(dto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(Guid id)
        {
            await _mediator.Send(new DeleteDepartamentoCommand(id));
            return NoContent();
        }
    }
}
