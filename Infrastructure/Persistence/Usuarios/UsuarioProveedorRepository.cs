using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;
using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Infrastructure.Persistence.Usuarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios{
    public class UsuarioProveedorRepository : IUsuarioProveedorRepository
{
    private readonly UsuarioDbContext _context;

    public UsuarioProveedorRepository(UsuarioDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UsuarioProveedor usuarioProveedor)
    {
        await _context.Set<UsuarioProveedor>().AddAsync(usuarioProveedor);
        await _context.SaveChangesAsync();
    }

    public async Task<UsuarioProveedor?> GetByIdAsync(Guid id)
    {
        return await _context.Set<UsuarioProveedor>().FindAsync(id);
    }

    public async Task<IEnumerable<UsuarioProveedor>> GetAllAsync()
    {
        return await _context.Set<UsuarioProveedor>().ToListAsync();
    }

    public async Task UpdateAsync(UsuarioProveedor usuarioProveedor)
    {
        _context.Set<UsuarioProveedor>().Update(usuarioProveedor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(UsuarioProveedor usuarioProveedor)
    {
        _context.Set<UsuarioProveedor>().Remove(usuarioProveedor);
        await _context.SaveChangesAsync();
    }
}


}





