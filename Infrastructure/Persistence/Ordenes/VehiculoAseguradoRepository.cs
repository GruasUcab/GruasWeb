using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Infrastructure.Persistence.Ordenes;
using Microsoft.EntityFrameworkCore;

public class VehiculoAseguradoRepository : IVehiculoAseguradoRepository
{
    private readonly OrdenDbContext _context;

    public VehiculoAseguradoRepository(OrdenDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VehiculoAsegurado>> GetAllAsync() =>
        await _context.VehiculosAsegurados.ToListAsync();

    public async Task<VehiculoAsegurado?> GetByIdAsync(Guid id) =>
        await _context.VehiculosAsegurados.FirstOrDefaultAsync(p => p.Id == id);

    public async Task AddAsync(VehiculoAsegurado vehiculoAsegurado)
    {
        await _context.VehiculosAsegurados.AddAsync(vehiculoAsegurado);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(VehiculoAsegurado vehiculoAsegurado)
    {
        _context.VehiculosAsegurados.Update(vehiculoAsegurado);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var vehiculoAsegurado = await GetByIdAsync(id);
        if (vehiculoAsegurado != null)
        {
            _context.VehiculosAsegurados.Remove(vehiculoAsegurado);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync(); // Persistir cambios
    }
}
