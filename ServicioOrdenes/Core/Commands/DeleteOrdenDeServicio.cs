using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{
public class DeleteOrdenDeServicioCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteOrdenDeServicioCommand(Guid id)
    {
        Id = id;
    }
}


}