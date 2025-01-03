using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{
public class DeletePolizaCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeletePolizaCommand(Guid id)
    {
        Id = id;
    }
}


}