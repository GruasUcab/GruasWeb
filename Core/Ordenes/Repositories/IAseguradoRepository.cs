using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Ordenes.Repositories
{
    public interface IAseguradoRepository
    {
        Task<Asegurado> GetByIdAsync(Guid id);
        Task<IEnumerable<Asegurado>> GetAllAsync();
        Task AddAsync(Asegurado asegurado);
        Task UpdateAsync(Asegurado asegurado);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
