using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrúasUCAB.Infrastructure.Persistence.Ordenes
{
    public class AseguradoRepository : IAseguradoRepository
    {
        private readonly OrdenDbContext _context;

        public AseguradoRepository(OrdenDbContext context)
        {
            _context = context;
        }

        public async Task<Asegurado> GetByIdAsync(Guid id)
        {
            var asegurado = await _context.Asegurados.FindAsync(id);
            if (asegurado == null)
            {
                throw new KeyNotFoundException($"Asegurado con ID {id} no encontrado.");
            }
            return asegurado;
        }

        public async Task<IEnumerable<Asegurado>> GetAllAsync() => await _context.Asegurados.ToListAsync();

        public async Task AddAsync(Asegurado asegurado) => await _context.Asegurados.AddAsync(asegurado);

        public Task UpdateAsync(Asegurado asegurado)
        {
            _context.Asegurados.Update(asegurado);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var asegurado = await GetByIdAsync(id);
            _context.Asegurados.Remove(asegurado);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
