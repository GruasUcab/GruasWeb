using MediatR;

namespace GrúasUCAB.Core.Usuarios.Commands
{
    public class CreateUsuarioCommand : IRequest<Guid>
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public bool Activo { get; set; }
        public string TipoUsuario { get; set; } = null!;
        public Guid DepartamentoId { get; set; }
    }
}
