using GrúasUCAB.Core.Usuarios.Dto;
using MediatR;

namespace GrúasUCAB.Core.Usuarios.Commands
{
    public class CreateUsuarioProveedorCommand : IRequest<Guid>
    {
        public CreateUsuarioProveedorDTO UsuarioDto { get; set; } = null!;
    }

}