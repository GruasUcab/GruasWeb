using GrúasUCAB.Core.Ordenes.Entities;
using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Core.Ordenes.Repositories;

namespace GrúasUCAB.Infrastructure.Persistence.Ordenes
{
    public class OrdenDeServicioRepository : IOrdenDeServicioRepository
{
    private readonly OrdenDbContext _context;

    public OrdenDeServicioRepository(OrdenDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrdenDeServicio>> GetAllAsync()
    {
        return await _context.OrdenesDeServicio.ToListAsync();
    }

    public async Task<OrdenDeServicio?> GetByIdAsync(Guid id)
    {
        return await _context.OrdenesDeServicio.FindAsync(id);
    }

    public async Task AddAsync(OrdenDeServicio ordenDeServicio)
    {
        await _context.OrdenesDeServicio.AddAsync(ordenDeServicio);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrdenDeServicio ordenDeServicio)
    {
        _context.OrdenesDeServicio.Update(ordenDeServicio);
         await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var orden = await GetByIdAsync(id);
        if (orden != null)
        {
            _context.OrdenesDeServicio.Remove(orden);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
}
