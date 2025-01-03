using GrúasUCAB.Core.Proveedores.Entities;

namespace GrúasUCAB.Core.Proveedores.Repositories
{
    public interface IConductorRepository
{
    Task<IEnumerable<Conductor>> GetAllAsync();
    Task<Conductor?> GetByIdAsync(Guid id);
    Task AddAsync(Conductor conductor);
    Task UpdateAsync(Conductor conductor);
    Task DeleteAsync(Guid id);
}
}
