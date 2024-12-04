using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GrúasUCAB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorRepository _repository;

        public ProveedorController(IProveedorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var proveedor = await _repository.GetByIdAsync(id);
            return proveedor != null ? Ok(proveedor) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _repository.GetAllAsync();
            return Ok(proveedores);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Proveedor proveedor)
        {
            await _repository.AddAsync(proveedor);
            await _repository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = proveedor.Id }, proveedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Proveedor proveedor)
        {
            if (id != proveedor.Id) return BadRequest();

            await _repository.UpdateAsync(proveedor);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
