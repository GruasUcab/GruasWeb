using MediatR;
using GrúasUCAB.Core.Proveedores.Dto;

namespace GrúasUCAB.Core.Proveedores.Commands
{

public class CreateConductorCommand : IRequest<Guid>
{
    public CreateConductorDTO ConductorDTO { get; }

    public CreateConductorCommand(CreateConductorDTO conductorDTO)
    {
        ConductorDTO = conductorDTO;
    }
}

}