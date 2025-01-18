using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Ordenes.Repositories
{
    public interface IVehiculoAseguradoRepository
    {
        Task<IEnumerable<VehiculoAsegurado>> GetAllAsync();
        Task<VehiculoAsegurado?> GetByIdAsync(Guid id);
        Task AddAsync(VehiculoAsegurado vehiculoAsegurado);
        Task UpdateAsync(VehiculoAsegurado vehiculoAsegurado);
        Task DeleteAsync(Guid id);        
        Task SaveChangesAsync();
    }
}
