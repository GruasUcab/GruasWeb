using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrúasUCAB.Infrastructure.Persistence.Usuarios
{
    /*public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _context;

        public UsuarioRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"Usuario con ID {id} no encontrado.");
            }
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync() => await _context.Usuarios.ToListAsync();

        public async Task AddAsync(Usuario usuario) => await _context.Usuarios.AddAsync(usuario);

        public Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var usuario = await GetByIdAsync(id);
            _context.Usuarios.Remove(usuario);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }*/
    public class UsuarioRepository : IUsuarioRepository
{
    private readonly UsuarioDbContext _context;

    public UsuarioRepository(UsuarioDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<Usuario> GetByIdAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"Usuario con ID {id} no encontrado.");
            }
            return usuario;
        }

    public async Task UpdateAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var usuario = await GetByIdAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}


}
