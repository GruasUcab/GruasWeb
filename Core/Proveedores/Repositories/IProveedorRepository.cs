using GrúasUCAB.Core.Proveedores.Entities;

namespace GrúasUCAB.Core.Proveedores.Repositories
{
    public interface IProveedorRepository
{
    Task AddAsync(Proveedor proveedor);
    Task<Proveedor?> GetByIdAsync(Guid id);
    Task<IEnumerable<Proveedor>> GetAllAsync();
    Task UpdateAsync(Proveedor proveedor);
    Task DeleteAsync(Guid id);
}

}
