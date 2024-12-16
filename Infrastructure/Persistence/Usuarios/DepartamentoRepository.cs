using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrúasUCAB.Infrastructure.Persistence.Usuarios
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly UsuarioDbContext _context;

        public DepartamentoRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public async Task<Departamento> GetByIdAsync(Guid id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                throw new KeyNotFoundException($"Departamento con ID {id} no encontrado.");
            }
            return departamento;
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync() => await _context.Departamentos.ToListAsync();

        public async Task AddAsync(Departamento departamento) => await _context.Departamentos.AddAsync(departamento);

        public Task UpdateAsync(Departamento departamento)
        {
            _context.Departamentos.Update(departamento);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var departamento = await GetByIdAsync(id);
            _context.Departamentos.Remove(departamento);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
