using GrúasUCAB.Core.Proveedores.Dto;
using GrúasUCAB.Core.Proveedores.Entities;
namespace GrúasUCAB.Core.Ordenes.Services.interfaces{


public interface IVehiculoService
{
    Task<Vehiculo?> GetVehiculoByIdAsync(Guid vehiculoId);
}
}