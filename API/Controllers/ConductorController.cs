using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GrúasUCAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {
        private readonly IConductorRepository _repository;

        public ConductorController(IConductorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var conductor = await _repository.GetByIdAsync(id);
                return Ok(conductor);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var conductores = await _repository.GetAllAsync();
            return Ok(conductores);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Conductor conductor)
        {
            await _repository.AddAsync(conductor);
            await _repository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = conductor.Id }, conductor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Conductor conductor)
        {
            if (id != conductor.Id) return BadRequest();

            await _repository.UpdateAsync(conductor);
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
