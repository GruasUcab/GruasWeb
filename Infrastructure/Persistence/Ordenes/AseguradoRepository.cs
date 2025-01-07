using Microsoft.EntityFrameworkCore;
using MediatR;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Infrastructure.Persistence.Ordenes;

namespace GrúasUCAB.Infrastructure.Persistence.Asegurados
{
    public class AseguradoRepository : IAseguradoRepository
    {
        private readonly OrdenDbContext _context;

        public AseguradoRepository(OrdenDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asegurado>> GetAllAsync()
        {
            return await _context.Asegurados.ToListAsync();
        }

        public async Task<Asegurado?> GetByIdAsync(Guid id)
        {
            return await _context.Asegurados.FindAsync(id);
        }

        public async Task AddAsync(Asegurado asegurado)
        {
            await _context.Asegurados.AddAsync(asegurado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Asegurado asegurado)
        {
            _context.Asegurados.Update(asegurado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var asegurado = await GetByIdAsync(id);
            if (asegurado != null)
            {
                _context.Asegurados.Remove(asegurado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
