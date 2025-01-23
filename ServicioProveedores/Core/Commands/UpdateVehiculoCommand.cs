using MediatR;
using GrúasUCAB.Core.Proveedores.DTO;

namespace GrúasUCAB.Core.Proveedores.Commands
{
    public class UpdateVehiculoCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public UpdateVehiculoDTO VehiculoDTO { get; set; }

    public UpdateVehiculoCommand(Guid id, UpdateVehiculoDTO vehiculoDTO)
    {
        Id = id;
        VehiculoDTO = vehiculoDTO;
    }
}

}
