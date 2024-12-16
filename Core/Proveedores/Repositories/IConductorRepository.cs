using GrúasUCAB.Core.Proveedores.Entities;

namespace GrúasUCAB.Core.Proveedores.Repositories
{
    public interface IConductorRepository
    {
        Task<Conductor> GetByIdAsync(Guid id);
        Task<IEnumerable<Conductor>> GetAllAsync();
        Task AddAsync(Conductor conductor);
        Task UpdateAsync(Conductor conductor);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
