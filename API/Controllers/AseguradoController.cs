using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GrúasUCAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseguradoController : ControllerBase
    {
        private readonly IAseguradoRepository _repository;

        public AseguradoController(IAseguradoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var asegurado = await _repository.GetByIdAsync(id);
                return Ok(asegurado);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var asegurados = await _repository.GetAllAsync();
            return Ok(asegurados);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Asegurado asegurado)
        {
            await _repository.AddAsync(asegurado);
            await _repository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = asegurado.Id }, asegurado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Asegurado asegurado)
        {
            if (id != asegurado.Id) return BadRequest();

            await _repository.UpdateAsync(asegurado);
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
