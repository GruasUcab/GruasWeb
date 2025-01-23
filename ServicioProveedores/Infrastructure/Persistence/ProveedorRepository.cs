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

    public async Task AddAsync(Proveedor proveedor)
    {
        await _context.Proveedores.AddAsync(proveedor);
        await _context.SaveChangesAsync();
    }

    public async Task<Proveedor?> GetByIdAsync(Guid id)
    {
        return await _context.Proveedores
            .Include(p => p.Vehiculos)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Proveedores
            .Include(p => p.Vehiculos)
            .ToListAsync();
    }

    public async Task UpdateAsync(Proveedor proveedor)
    {
        _context.Proveedores.Update(proveedor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var proveedor = await GetByIdAsync(id);
        if (proveedor != null)
        {
            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
        }
    }
}

}
