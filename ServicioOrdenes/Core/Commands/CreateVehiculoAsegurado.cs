using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{
public class CreateVehiculoAseguradoCommand : IRequest<Guid>
{
    public CreateVehiculoAseguradoDTO VehiculoAseguradoDTO { get; set; }

    public CreateVehiculoAseguradoCommand(CreateVehiculoAseguradoDTO vehiculoAseguradoDTO)
    {
        VehiculoAseguradoDTO = vehiculoAseguradoDTO;
    }
}


}