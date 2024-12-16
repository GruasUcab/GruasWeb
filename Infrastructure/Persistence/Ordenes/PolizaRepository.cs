using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrúasUCAB.Infrastructure.Persistence.Ordenes
{
    public class PolizaRepository : IPolizaRepository
    {
        private readonly OrdenDbContext _context;

        public PolizaRepository(OrdenDbContext context)
        {
            _context = context;
        }

        public async Task<Poliza> GetByIdAsync(Guid id)
        {
            var poliza = await _context.Polizas.FindAsync(id);
            if (poliza == null)
            {
                throw new KeyNotFoundException($"Poliza con ID {id} no encontrada.");
            }
            return poliza;
        }

        public async Task<IEnumerable<Poliza>> GetAllAsync() => await _context.Polizas.ToListAsync();

        public async Task AddAsync(Poliza poliza) => await _context.Polizas.AddAsync(poliza);

        public Task UpdateAsync(Poliza poliza)
        {
            _context.Polizas.Update(poliza);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var poliza = await GetByIdAsync(id);
            _context.Polizas.Remove(poliza);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
