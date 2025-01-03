using MediatR;
using GrúasUCAB.Core.Proveedores.Dto;

namespace GrúasUCAB.Core.Proveedores.Commands
{
    public class DeleteConductorCommand : IRequest<Unit>
{
    public Guid Id { get; }

    public DeleteConductorCommand(Guid id)
    {
        Id = id;
    }
}
}