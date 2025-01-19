using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostoFinalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CostoFinalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CalcularCostoFinal([FromBody] CostoFinalCommand command)
        {
            var id = await _mediator.Send(command);
            return NoContent();
        }
    }
}
