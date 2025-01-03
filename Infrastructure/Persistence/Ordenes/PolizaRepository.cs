using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Infrastructure.Persistence.Ordenes;
using Microsoft.EntityFrameworkCore;

public class PolizaRepository : IPolizaRepository
{
    private readonly OrdenDbContext _context;

    public PolizaRepository(OrdenDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Poliza>> GetAllAsync() =>
        await _context.Polizas.ToListAsync();

    public async Task<Poliza?> GetByIdAsync(Guid id) =>
        await _context.Polizas.FirstOrDefaultAsync(p => p.Id == id);

    public async Task AddAsync(Poliza poliza)
    {
        await _context.Polizas.AddAsync(poliza);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Poliza poliza)
    {
        _context.Polizas.Update(poliza);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var poliza = await GetByIdAsync(id);
        if (poliza != null)
        {
            _context.Polizas.Remove(poliza);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync(); // Persistir cambios
    }
}
