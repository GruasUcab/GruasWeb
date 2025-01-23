using MediatR;
using GrúasUCAB.Core.Proveedores.Dto;

namespace GrúasUCAB.Core.Proveedores.Commands
{
    public class UpdateConductorUbicacionCommand : IRequest<Unit>    
{
    public Guid Id {get; set;}
    public UpdateConductorUbicacionDTO ConductorDTO { get; }

    public UpdateConductorUbicacionCommand(Guid id, UpdateConductorUbicacionDTO conductorDTO)
    {
        Id = id;
        ConductorDTO = conductorDTO;
    }
}
}