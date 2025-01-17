using GrúasUCAB.Core.Usuarios.Dto;
using MediatR;

namespace GrúasUCAB.Core.Usuarios.Commands
{
   public class UpdateUsuarioCommand : IRequest<Unit>
{
    public UpdateUsuarioDTO UsuarioDTO { get; set; }

    public UpdateUsuarioCommand(UpdateUsuarioDTO usuarioDto)
    {
        UsuarioDTO = usuarioDto;
    }

}




}
