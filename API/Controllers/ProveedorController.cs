using GrúasUCAB.Core.Proveedores.Commands;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrúasUCAB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProveedorRepository _repository;

        public ProveedorController(IMediator mediator, IProveedorRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProveedorRequestDto dto)
        {
            var command = new CreateProveedorCommand
            {
                Nombre = dto.Nombre,
                Tipo = dto.Tipo,
                Direccion = dto.Direccion,
                Email = dto.Email,
                Activo = dto.Activo
            };

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, new { Message = "Proveedor creado exitosamente", Id = id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProveedorRequestDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(new { Message = "El ID del proveedor no coincide con el comando." });
            }

            var command = new UpdateProveedorCommand
            {
                Id = id,
                Nombre = dto.Nombre,
                Tipo = dto.Tipo,
                Direccion = dto.Direccion,
                Email = dto.Email,
                Activo = dto.Activo
            };

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteProveedorCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var proveedor = await _repository.GetByIdAsync(id);
            if (proveedor == null)
            {
                return NotFound(new { Message = $"Proveedor con ID {id} no encontrado." });
            }

            var response = new ProveedorResponseDto
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                Tipo = proveedor.Tipo,
                Direccion = proveedor.Direccion,
                Email = proveedor.Email,
                Activo = proveedor.Activo
            };

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _repository.GetAllAsync();
            var response = proveedores.Select(proveedor => new ProveedorResponseDto
            {
                Id = proveedor.Id,
                Nombre = proveedor.Nombre,
                Tipo = proveedor.Tipo,
                Direccion = proveedor.Direccion,
                Email = proveedor.Email,
                Activo = proveedor.Activo
            });

            return Ok(response);
        }
    }
}
