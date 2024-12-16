using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GrúasUCAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaRepository _repository;

        public PolizaController(IPolizaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var poliza = await _repository.GetByIdAsync(id);
                return Ok(poliza);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var polizas = await _repository.GetAllAsync();
            return Ok(polizas);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Poliza poliza)
        {
            await _repository.AddAsync(poliza);
            await _repository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = poliza.Id }, poliza);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Poliza poliza)
        {
            if (id != poliza.Id) return BadRequest();

            await _repository.UpdateAsync(poliza);
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
