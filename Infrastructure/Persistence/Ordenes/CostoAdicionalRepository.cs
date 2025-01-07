using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Entities;
using MediatR;
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

        public async Task<IEnumerable<CostoAdicional>> GetAllAsync()
        {
            return await _context.CostosAdicionales.Include(c => c.Orden).ToListAsync();
        }

        public async Task<CostoAdicional?> GetByIdAsync(Guid id)
        {
            return await _context.CostosAdicionales.Include(c => c.Orden)
                                                  .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(CostoAdicional costoAdicional)
        {
            await _context.CostosAdicionales.AddAsync(costoAdicional);
        }

        public async Task UpdateAsync(CostoAdicional costoAdicional)
        {
            _context.CostosAdicionales.Update(costoAdicional);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CostoAdicional costoAdicional)
        {
            _context.CostosAdicionales.Remove(costoAdicional);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
