using GrúasUCAB.Core.Usuarios.Entities;

namespace GrúasUCAB.Core.Usuarios.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<Departamento> GetByIdAsync(Guid id);
        Task<IEnumerable<Departamento>> GetAllAsync();
        Task AddAsync(Departamento departamento);
        Task UpdateAsync(Departamento departamento);
        Task DeleteAsync(Guid id);
        Task SaveChangesAsync();
    }
}
