using GrúasUCAB.Core.Proveedores.Entities;

namespace GrúasUCAB.Core.Proveedores.Repositories
{
public interface IVehiculoRepository
{
    Task AddAsync(Vehiculo vehiculo);
    Task<Vehiculo?> GetByIdAsync(Guid id);
    Task<IEnumerable<Vehiculo>> GetAllAsync();
    Task<IEnumerable<Vehiculo>> GetAllByProveedorIdAsync(Guid proveedorId);
    Task UpdateAsync(Vehiculo vehiculo);
    Task DeleteAsync(Vehiculo vehiculo);
}

}
