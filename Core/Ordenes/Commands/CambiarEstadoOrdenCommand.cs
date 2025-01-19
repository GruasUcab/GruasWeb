using MediatR;
using GrúasUCAB.Core.Ordenes.Entities;
namespace GrúasUCAB.Core.Ordenes.Commands{
public class CambiarEstadoOrdenCommand : IRequest<bool>
{
    public Guid OrdenId { get; set; }
    public EstadoOrden NuevoEstado { get; set; }
}
}
