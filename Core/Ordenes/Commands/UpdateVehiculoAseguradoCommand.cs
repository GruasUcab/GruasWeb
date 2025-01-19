using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{
    public class UpdateVehiculoAseguradoCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public UpdateVehiculoAseguradoDTO VehiculoAseguradoDTO { get; set; }

    public UpdateVehiculoAseguradoCommand(Guid id, UpdateVehiculoAseguradoDTO vehiculoAseguradoDTO)
    {
        Id = id;
        VehiculoAseguradoDTO = vehiculoAseguradoDTO;
    }
}

}