using GrúasUCAB.Core.Proveedores.Entities;

namespace GrúasUCAB.Core.Proveedores.Repositories
{
    public interface IProveedorRepository
    {
        Task<Proveedor> GetByIdAsync(Guid id);
        Task<IEnumerable<Proveedor>> GetAllAsync();
        Task AddAsync(Proveedor proveedor);
        Task UpdateAsync(Proveedor proveedor);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
