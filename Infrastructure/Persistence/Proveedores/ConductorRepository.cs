using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrúasUCAB.Infrastructure.Persistence.Proveedores
{
    public class ConductorRepository : IConductorRepository
    {
        private readonly ProveedorDbContext _context;

        public ConductorRepository(ProveedorDbContext context)
        {
            _context = context;
        }

        public async Task<Conductor> GetByIdAsync(Guid id)
        {
            var conductor = await _context.Conductores.FindAsync(id);
            if (conductor == null)
            {
                throw new KeyNotFoundException($"Conductor con ID {id} no encontrado.");
            }
            return conductor;
        }

        public async Task<IEnumerable<Conductor>> GetAllAsync() => await _context.Conductores.ToListAsync();

        public async Task AddAsync(Conductor conductor) => await _context.Conductores.AddAsync(conductor);

        public Task UpdateAsync(Conductor conductor)
        {
            _context.Conductores.Update(conductor);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var conductor = await GetByIdAsync(id);
            _context.Conductores.Remove(conductor);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
