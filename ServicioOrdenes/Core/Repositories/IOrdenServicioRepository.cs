using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Repositories
{
    public interface IOrdenDeServicioRepository
{
    Task<IEnumerable<OrdenDeServicio>> GetAllAsync();
    Task<OrdenDeServicio?> GetByIdAsync(Guid id);
    Task AddAsync(OrdenDeServicio ordenDeServicio);
    Task UpdateAsync(OrdenDeServicio ordenDeServicio);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}


}
