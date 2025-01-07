using MediatR;

namespace GrúasUCAB.Core.Ordenes.Commands{

public class DeleteCostoAdicionalCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteCostoAdicionalCommand(Guid id)
    {
        Id = id;
    }
}

}