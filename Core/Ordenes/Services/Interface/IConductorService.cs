using GrúasUCAB.Core.Proveedores.Dto;
namespace GrúasUCAB.Core.Ordenes.Services.interfaces{


public interface IConductorService
{
    Task<ConductorDTO?> GetConductorByIdAsync(Guid conductorId);
}
}