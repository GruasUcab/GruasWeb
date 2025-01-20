using MediatR;
using GrúasUCAB.Core.Proveedores.Dto;

namespace GrúasUCAB.Core.Proveedores.Commands
{
    public class UpdateConductorUbicacionCommand : IRequest<Unit>
{
    public UpdateConductorUbicacionDTO ConductorDTO { get; }

    public UpdateConductorUbicacionCommand(UpdateConductorUbicacionDTO conductorDTO)
    {
        ConductorDTO = conductorDTO;
    }
}
}