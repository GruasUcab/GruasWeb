using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrúasUCAB.Infrastructure.Persistence.Proveedores
{
    public class ConductorRepository : IConductorRepository
{
    private readonly ProveedorDbContext _context;

    public ConductorRepository(ProveedorDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Conductor>> GetAllAsync()
    {
        return await _context.Conductores.ToListAsync();
    }

    public async Task<Conductor?> GetByIdAsync(Guid id)
    {
        return await _context.Conductores.FindAsync(id);
    }

    public async Task AddAsync(Conductor conductor)
    {
        await _context.Conductores.AddAsync(conductor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Conductor conductor)
    {
        _context.Conductores.Update(conductor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var conductor = await GetByIdAsync(id);
        if (conductor != null)
        {
            _context.Conductores.Remove(conductor);
            await _context.SaveChangesAsync();
        }
    }
}
}
