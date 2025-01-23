using GrúasUCAB.Core.Usuarios.Dto;
using MediatR;

namespace GrúasUCAB.Core.Usuarios.Commands
{
    public class CreateUsuarioCommand : IRequest<Guid>
    {
        public CreateUsuarioDTO UsuarioDto { get; set; } = null!;
    }
}
