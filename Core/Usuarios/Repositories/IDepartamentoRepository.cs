using GrúasUCAB.Core.Usuarios.Entities;

namespace GrúasUCAB.Core.Usuarios.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> GetAllAsync();
        Task<Departamento?> GetByIdAsync(Guid id);
        Task AddAsync(Departamento departamento);
        Task UpdateAsync(Departamento departamento);
        Task DeleteAsync(Departamento departamento);
    }
}
