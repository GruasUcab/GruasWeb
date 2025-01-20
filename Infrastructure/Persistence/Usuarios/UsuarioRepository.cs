using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;
using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Infrastructure.Persistence.Usuarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace GrúasUCAB.Infrastructure.Handlers.Usuarios{
    public class UsuarioRepository : IUsuarioRepository
{
    private readonly UsuarioDbContext _context;

    public UsuarioRepository(UsuarioDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Usuario usuario)
    {
        await _context.Set<Usuario>().AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<Usuario?> GetByIdAsync(Guid id)
    {
        return await _context.Set<Usuario>().FindAsync(id);
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Set<Usuario>().ToListAsync();
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        _context.Set<Usuario>().Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Usuario usuario)
    {
        _context.Set<Usuario>().Remove(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync(Expression<Func<Usuario, bool>> predicate)
{
    return await _context.Usuarios.Where(predicate).ToListAsync();
}


}}





