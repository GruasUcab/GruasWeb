using MediatR;
using GrúasUCAB.Core.Proveedores.Dto;

namespace GrúasUCAB.Core.Proveedores.Commands
{
    public class UpdateProveedorCommand : IRequest<Unit>
{
    public UpdateProveedorDTO ProveedorDto { get; }

    public UpdateProveedorCommand(UpdateProveedorDTO proveedorDto)
    {
        ProveedorDto = proveedorDto;
    }
}
}

