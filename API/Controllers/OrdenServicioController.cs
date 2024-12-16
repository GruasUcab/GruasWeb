using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GrúasUCAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenServicioController : ControllerBase
    {
        private readonly IOrdenServicioRepository _repository;

        public OrdenServicioController(IOrdenServicioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var ordenServicio = await _repository.GetByIdAsync(id);
                return Ok(ordenServicio);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ordenes = await _repository.GetAllAsync();
            return Ok(ordenes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrdenServicio ordenServicio)
        {
            await _repository.AddAsync(ordenServicio);
            await _repository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = ordenServicio.Id }, ordenServicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, OrdenServicio ordenServicio)
        {
            if (id != ordenServicio.Id) return BadRequest();

            await _repository.UpdateAsync(ordenServicio);
            await _repository.SaveChangesAsync();
            return NoContent();
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
