using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Ordenes.Repositories
{
    public interface IOrdenServicioRepository
    {
        Task<OrdenServicio> GetByIdAsync(Guid id);
        Task<IEnumerable<OrdenServicio>> GetAllAsync();
        Task AddAsync(OrdenServicio ordenServicio);
        Task UpdateAsync(OrdenServicio ordenServicio);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
