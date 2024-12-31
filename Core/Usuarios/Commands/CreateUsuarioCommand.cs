using MediatR;
using GrúasUCAB.Core.Usuarios.DTOs;

namespace GrúasUCAB.Core.Usuarios.Commands
{
    public class CreateUsuarioCommand : IRequest<Guid>
{
    public CreateUsuarioDTO UsuarioDto { get; set; }

    public CreateUsuarioCommand(CreateUsuarioDTO usuarioDto)
    {
        UsuarioDto = usuarioDto;
    }
}

}
