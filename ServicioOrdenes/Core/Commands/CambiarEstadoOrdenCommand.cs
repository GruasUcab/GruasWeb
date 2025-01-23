using MediatR;
using GrúasUCAB.Core.Ordenes.Entities;
namespace GrúasUCAB.Core.Ordenes.Commands{
public class AsignarOrdenCommand : IRequest<Unit>
{
    public Guid OrdenId { get; set; }
    public Guid ConductorId { get; set; }
}
}