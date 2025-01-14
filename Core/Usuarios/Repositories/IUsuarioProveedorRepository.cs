using GrúasUCAB.Core.Usuarios.Entities;

namespace GrúasUCAB.Core.Usuarios.Repositories
{
    
public interface IUsuarioProveedorRepository
{
    Task AddAsync(UsuarioProveedor usuarioProveedor);
    Task<UsuarioProveedor?> GetByIdAsync(Guid id);
    Task<IEnumerable<UsuarioProveedor>> GetAllAsync();
    Task UpdateAsync(UsuarioProveedor usuarioProveedor);
    Task DeleteAsync(UsuarioProveedor usuarioProveedor);
}



}
