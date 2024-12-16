using GrúasUCAB.Core.Proveedores.Entities;

namespace GrúasUCAB.Core.Proveedores.Repositories
{
    public interface IVehiculoRepository
    {
        Task<Vehiculo> GetByIdAsync(Guid id);
        Task<IEnumerable<Vehiculo>> GetAllAsync();
        Task AddAsync(Vehiculo vehiculo);
        Task UpdateAsync(Vehiculo vehiculo);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
