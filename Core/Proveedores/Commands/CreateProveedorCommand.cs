using MediatR;

namespace GrúasUCAB.Core.Proveedores.Commands
{
    public class CreateProveedorCommand : IRequest<Guid>
    {
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
