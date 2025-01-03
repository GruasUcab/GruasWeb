using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Ordenes.Repositories
{
    public interface IOrdenDeServicioRepository
{
    Task<IEnumerable<OrdenDeServicio>> GetAllAsync();
    Task<OrdenDeServicio?> GetByIdAsync(Guid id);
    Task AddAsync(OrdenDeServicio orden);
    Task UpdateAsync(OrdenDeServicio orden);
    Task DeleteAsync(Guid id);
}


}
