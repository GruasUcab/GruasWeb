using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrúasUCAB.Infrastructure.Persistence.Ordenes
{
    public class OrdenServicioRepository : IOrdenServicioRepository
    {
        private readonly OrdenDbContext _context;

        public OrdenServicioRepository(OrdenDbContext context)
        {
            _context = context;
        }

        public async Task<OrdenServicio> GetByIdAsync(Guid id)
        {
            var ordenServicio = await _context.Ordenes
                .Include(o => o.Conductor)
                .Include(o => o.Proveedor)
                .Include(o => o.Vehiculo)
                .Include(o => o.CostosAdicionales)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (ordenServicio == null)
            {
                throw new KeyNotFoundException($"Orden de servicio con ID {id} no encontrada.");
            }
            return ordenServicio;
        }

        public async Task<IEnumerable<OrdenServicio>> GetAllAsync()
        {
            return await _context.Ordenes
                .Include(o => o.Conductor)
                .Include(o => o.Proveedor)
                .Include(o => o.Vehiculo)
                .Include(o => o.CostosAdicionales)
                .ToListAsync();
        }

        public async Task AddAsync(OrdenServicio ordenServicio) => await _context.Ordenes.AddAsync(ordenServicio);

        public Task UpdateAsync(OrdenServicio ordenServicio)
        {
            _context.Ordenes.Update(ordenServicio);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var ordenServicio = await GetByIdAsync(id);
            _context.Ordenes.Remove(ordenServicio);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
