using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrúasUCAB.Infrastructure.Persistence.Ordenes
{
    public class CostoAdicionalRepository : ICostoAdicionalRepository
    {
        private readonly OrdenDbContext _context;

        public CostoAdicionalRepository(OrdenDbContext context)
        {
            _context = context;
        }

        public async Task<CostoAdicional> GetByIdAsync(Guid id)
        {
            var costoAdicional = await _context.CostosAdicionales.FindAsync(id);
            if (costoAdicional == null)
            {
                throw new KeyNotFoundException($"Costo Adicional con ID {id} no encontrado.");
            }
            return costoAdicional;
        }

        public async Task<IEnumerable<CostoAdicional>> GetAllAsync() => await _context.CostosAdicionales.ToListAsync();

        public async Task AddAsync(CostoAdicional costoAdicional) => await _context.CostosAdicionales.AddAsync(costoAdicional);

        public Task UpdateAsync(CostoAdicional costoAdicional)
        {
            _context.CostosAdicionales.Update(costoAdicional);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var costoAdicional = await GetByIdAsync(id);
            _context.CostosAdicionales.Remove(costoAdicional);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
