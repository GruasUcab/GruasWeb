using GrúasUCAB.Infrastructure.Persistence.Proveedores;
using GrúasUCAB.Core.Proveedores.Repositories;
using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Core.Proveedores.Entities;
public class VehiculoRepository : IVehiculoRepository
{
    private readonly ProveedorDbContext _context;

    public VehiculoRepository(ProveedorDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Vehiculo vehiculo)
    {
        await _context.Vehiculos.AddAsync(vehiculo);
        await _context.SaveChangesAsync();
    }

    /*public async Task<Vehiculo?> GetByIdAsync(Guid id)
    {
        return await _context.Vehiculos
        .AsNoTracking() // Evita problemas de seguimiento
        .Include(v => v.Proveedor) // Incluye la navegación a Proveedor
        .FirstOrDefaultAsync(v => v.Id == id);
    }*/

    public async Task<Vehiculo?> GetByIdAsync(Guid id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                throw new KeyNotFoundException($"Vehiculo con ID {id} no encontrado.");
            }
            return vehiculo;
        }


    public async Task<IEnumerable<Vehiculo>> GetAllAsync()
    {
        return await _context.Vehiculos.Include(v => v.Proveedor).ToListAsync();
    }

    public async Task<IEnumerable<Vehiculo>> GetAllByProveedorIdAsync(Guid proveedorId)
    {
        return await _context.Vehiculos.Where(v => v.ProveedorId == proveedorId).ToListAsync();
    }

    public async Task UpdateAsync(Vehiculo vehiculo)
    {
        _context.Vehiculos.Update(vehiculo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Vehiculo vehiculo)
    {
        _context.Vehiculos.Remove(vehiculo);
        await _context.SaveChangesAsync();
    }
}

