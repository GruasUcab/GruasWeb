using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{
public class CreateOrdenDeServicioCommand : IRequest<Guid>
{
    public CreateOrdenDeServicioDTO OrdenDeServicioDTO { get; set; }

    public CreateOrdenDeServicioCommand(CreateOrdenDeServicioDTO ordenDeServicioDTO)
    {
        OrdenDeServicioDTO = ordenDeServicioDTO;
    }
}


}