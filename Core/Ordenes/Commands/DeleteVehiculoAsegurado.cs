using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{
public class DeleteVehiculoAseguradoCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteVehiculoAseguradoCommand(Guid id)
    {
        Id = id;
    }
}


}