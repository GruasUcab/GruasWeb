using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Ordenes.Repositories
{
    public interface IPolizaRepository
    {
        Task<Poliza> GetByIdAsync(Guid id);
        Task<IEnumerable<Poliza>> GetAllAsync();
        Task AddAsync(Poliza poliza);
        Task UpdateAsync(Poliza poliza);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
