using MediatR;
using GrúasUCAB.Core.Proveedores.Dto;

namespace GrúasUCAB.Core.Proveedores.Commands
{
   public class DeleteProveedorCommand : IRequest<Unit>
{
    public Guid Id { get; }

    public DeleteProveedorCommand(Guid id)
    {
        Id = id;
    }
}

}

