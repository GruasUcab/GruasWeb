using MediatR;
using GrúasUCAB.Core.Proveedores.Dto;

namespace GrúasUCAB.Core.Proveedores.Commands
{
   public class DeleteVehiculoCommand : IRequest<Unit>
{
    public Guid Id { get; }

    public DeleteVehiculoCommand(Guid id)
    {
        Id = id;
    }
}

}
