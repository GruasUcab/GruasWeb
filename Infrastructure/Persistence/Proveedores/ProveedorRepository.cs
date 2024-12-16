using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace GrúasUCAB.Infrastructure.Persistence.Proveedores
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ProveedorDbContext _context;

        public ProveedorRepository(ProveedorDbContext context)
        {
            _context = context;
        }

        public async Task<Proveedor> GetByIdAsync(Guid id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                throw new KeyNotFoundException($"Proveedor con ID {id} no encontrado.");
            }
            return proveedor;
        }

        public async Task<IEnumerable<Proveedor>> GetAllAsync() => await _context.Proveedores.ToListAsync();

        public async Task AddAsync(Proveedor proveedor) => await _context.Proveedores.AddAsync(proveedor);

        public Task UpdateAsync(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var proveedor = await GetByIdAsync(id);
            _context.Proveedores.Remove(proveedor);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
