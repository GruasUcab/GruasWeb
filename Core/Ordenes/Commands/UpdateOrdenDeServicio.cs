using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{
    public class UpdateOrdenDeServicioCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public UpdateOrdenDeServicioDTO OrdenDeServicioDTO { get; set; }

    public UpdateOrdenDeServicioCommand(Guid id, UpdateOrdenDeServicioDTO ordenDeServicioDTO)
    {
        Id = id;
        OrdenDeServicioDTO = ordenDeServicioDTO;
    }
}

}