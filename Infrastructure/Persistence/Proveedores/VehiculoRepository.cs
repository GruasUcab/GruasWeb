using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrúasUCAB.Infrastructure.Persistence.Proveedores
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly ProveedorDbContext _context;

        public VehiculoRepository(ProveedorDbContext context)
        {
            _context = context;
        }

        public async Task<Vehiculo> GetByIdAsync(Guid id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                throw new KeyNotFoundException($"Vehículo con ID {id} no encontrado.");
            }
            return vehiculo;
        }

        public async Task<IEnumerable<Vehiculo>> GetAllAsync() => await _context.Vehiculos.ToListAsync();

        public async Task AddAsync(Vehiculo vehiculo) => await _context.Vehiculos.AddAsync(vehiculo);

        public Task UpdateAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Update(vehiculo);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var vehiculo = await GetByIdAsync(id);
            _context.Vehiculos.Remove(vehiculo);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
