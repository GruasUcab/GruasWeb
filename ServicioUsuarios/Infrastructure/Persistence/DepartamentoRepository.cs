using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Infrastructure.Persistence.Usuarios;
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

        public async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<Departamento?> GetByIdAsync(Guid id)
        {
            return await _context.Departamentos.FindAsync(id);
        }

        public async Task AddAsync(Departamento departamento)
        {
            await _context.Departamentos.AddAsync(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Departamento departamento)
        {
            _context.Departamentos.Update(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Departamento departamento)
        {
            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
        }
    }
}
