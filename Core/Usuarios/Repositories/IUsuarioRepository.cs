using GrúasUCAB.Core.Usuarios.Entities;
using System.Linq.Expressions;


namespace GrúasUCAB.Core.Usuarios.Repositories
{
    /*public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(Guid id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    } */

public interface IUsuarioRepository
{
    Task AddAsync(Usuario usuario);
    Task<Usuario?> GetByIdAsync(Guid id);
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(Usuario usuario);
    Task<IEnumerable<Usuario>> GetAllAsync(Expression<Func<Usuario, bool>> predicate);
    Task<Usuario?> GetBySubAsync(string sub);
}



}
