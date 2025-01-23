using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Ordenes.Repositories
{
    public interface ICostoAdicionalRepository
    {
        Task<IEnumerable<CostoAdicional>> GetAllAsync();
        Task<CostoAdicional?> GetByIdAsync(Guid id);
        Task AddAsync(CostoAdicional costoAdicional);
        Task UpdateAsync(CostoAdicional costoAdicional);
        Task DeleteAsync(CostoAdicional costoAdicional);
        Task<List<CostoAdicional>> GetByOrdenIdAsync(Guid ordenId);
        Task SaveChangesAsync();
    }
}
