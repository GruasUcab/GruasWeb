using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Ordenes.Repositories
{
    public interface IPolizaRepository
    {
        Task<IEnumerable<Poliza>> GetAllAsync();
        Task<Poliza?> GetByIdAsync(Guid id);
        Task AddAsync(Poliza poliza);
        Task UpdateAsync(Poliza poliza);
        Task DeleteAsync(Guid id);        
        Task SaveChangesAsync();
    }
}
