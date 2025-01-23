using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Ordenes.Repositories
{
    public interface IAseguradoRepository
    {
        Task<IEnumerable<Asegurado>> GetAllAsync();
        Task<Asegurado?> GetByIdAsync(Guid id);
        Task AddAsync(Asegurado asegurado);
        Task UpdateAsync(Asegurado asegurado);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}

