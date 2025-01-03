using GrúasUCAB.Core.Proveedores.DTO;
using MediatR;

namespace GrúasUCAB.Core.Proveedores.Commands
{
    public class CreateVehiculoCommand : IRequest<Guid>
{
    public CreateVehiculoDTO VehiculoDTO { get; set; }

    public CreateVehiculoCommand(CreateVehiculoDTO vehiculoDTO)
    {
        VehiculoDTO = vehiculoDTO;
    }
}


}
