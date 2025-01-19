using MediatR;
namespace GrúasUCAB.Core.Ordenes.Commands{
public class AsignarOrdenCommand : IRequest <Unit>
{
    public Guid OrdenId { get; set; }
}
}
