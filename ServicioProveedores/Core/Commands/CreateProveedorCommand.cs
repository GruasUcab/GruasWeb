using MediatR;
using GrúasUCAB.Core.Proveedores.Dto;

namespace GrúasUCAB.Core.Proveedores.Commands
{
    public class CreateProveedorCommand : IRequest<Guid>
{
    public CreateProveedorDTO ProveedorDto { get; }

    public CreateProveedorCommand(CreateProveedorDTO proveedorDto)
    {
        ProveedorDto = proveedorDto;
    }
}

}
