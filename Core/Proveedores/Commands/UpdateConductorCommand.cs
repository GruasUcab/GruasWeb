using MediatR;
using GrúasUCAB.Core.Proveedores.Dto;

namespace GrúasUCAB.Core.Proveedores.Commands
{
    public class UpdateConductorCommand : IRequest<Unit>
{
    public UpdateConductorDTO ConductorDTO { get; }

    public UpdateConductorCommand(UpdateConductorDTO conductorDTO)
    {
        ConductorDTO = conductorDTO;
    }
}
}