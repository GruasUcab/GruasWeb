using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GrúasUCAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostoAdicionalController : ControllerBase
    {
        private readonly ICostoAdicionalRepository _repository;

        public CostoAdicionalController(ICostoAdicionalRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var costoAdicional = await _repository.GetByIdAsync(id);
                var response = new CostoAdicionalResponseDto
                {
                    Id = costoAdicional.Id,
                    Nombre = costoAdicional.Nombre,
                    Monto = costoAdicional.Monto,
                    OrdenId = costoAdicional.OrdenId
                };
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var costosAdicionales = await _repository.GetAllAsync();
            var response = costosAdicionales.Select(c => new CostoAdicionalResponseDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Monto = c.Monto,
                OrdenId = c.OrdenId
            });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CostoAdicionalRequestDto dto)
        {
            var costoAdicional = new CostoAdicional(
                Guid.NewGuid(),
                dto.Nombre,
                dto.Monto,
                dto.OrdenId
            );

            await _repository.AddAsync(costoAdicional);
            await _repository.SaveChangesAsync();

            var response = new CostoAdicionalResponseDto
            {
                Id = costoAdicional.Id,
                Nombre = costoAdicional.Nombre,
                Monto = costoAdicional.Monto,
                OrdenId = costoAdicional.OrdenId
            };

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CostoAdicionalRequestDto dto)
        {
            try
            {
                var costoAdicional = await _repository.GetByIdAsync(id);

                costoAdicional = new CostoAdicional(
                    id,
                    dto.Nombre,
                    dto.Monto,
                    dto.OrdenId
                );

                await _repository.UpdateAsync(costoAdicional);
                await _repository.SaveChangesAsync();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                await _repository.SaveChangesAsync();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
