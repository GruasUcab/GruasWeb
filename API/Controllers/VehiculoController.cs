using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GrúasUCAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoRepository _repository;

        public VehiculoController(IVehiculoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var vehiculo = await _repository.GetByIdAsync(id);
                return Ok(vehiculo);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehiculos = await _repository.GetAllAsync();
            return Ok(vehiculos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehiculo vehiculo)
        {
            await _repository.AddAsync(vehiculo);
            await _repository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = vehiculo.Id }, vehiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id) return BadRequest();

            await _repository.UpdateAsync(vehiculo);
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
