using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrúasUCAB.Infrastructure.Persistence.Proveedores
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly AppDbContext _context;

        public ProveedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Proveedor> GetByIdAsync(Guid id) => await _context.Proveedores.FindAsync(id);

        public async Task<IEnumerable<Proveedor>> GetAllAsync() => await _context.Proveedores.ToListAsync();

        public async Task AddAsync(Proveedor proveedor) => await _context.Proveedores.AddAsync(proveedor);

        public async Task UpdateAsync(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
        }

        public async Task DeleteAsync(Guid id)
        {
            var proveedor = await GetByIdAsync(id);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
            }
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
