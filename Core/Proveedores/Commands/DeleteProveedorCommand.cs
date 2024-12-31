using MediatR;

namespace GrúasUCAB.Core.Proveedores.Commands
{
    public class DeleteProveedorCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
