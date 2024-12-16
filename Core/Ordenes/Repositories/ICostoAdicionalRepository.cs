using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Ordenes.Repositories
{
    public interface ICostoAdicionalRepository
    {
        Task<CostoAdicional> GetByIdAsync(Guid id);
        Task<IEnumerable<CostoAdicional>> GetAllAsync();
        Task AddAsync(CostoAdicional costoAdicional);
        Task UpdateAsync(CostoAdicional costoAdicional);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
