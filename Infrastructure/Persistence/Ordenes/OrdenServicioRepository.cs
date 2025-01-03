using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using Microsoft.EntityFrameworkCore;

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
        return await _context.OrdenDeServicios
            .Include(o => o.Conductor)
            .Include(o => o.Proveedor)
            .Include(o => o.Vehiculo)
            .ToListAsync();
    }

    public async Task<OrdenDeServicio?> GetByIdAsync(Guid id)
    {
        return await _context.OrdenDeServicios
            .Include(o => o.Conductor)
            .Include(o => o.Proveedor)
            .Include(o => o.Vehiculo)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAsync(OrdenDeServicio orden)
    {
        _context.OrdenDeServicios.Add(orden);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrdenDeServicio orden)
    {
        _context.OrdenDeServicios.Update(orden);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var orden = await GetByIdAsync(id);
        if (orden != null)
        {
            _context.OrdenDeServicios.Remove(orden);
            await _context.SaveChangesAsync();
        }
    }
}


}
