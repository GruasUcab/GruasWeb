using GrúasUCAB.Core.Usuarios.Dto;
using MediatR;

namespace GrúasUCAB.Core.Usuarios.Commands
{
   public class UpdateUsuarioProveedorCommand : IRequest<Unit>
{
    public UpdateUsuarioProveedorDTO UsuarioDTO { get; set; }

    public UpdateUsuarioProveedorCommand(UpdateUsuarioProveedorDTO usuarioDto)
    {
        UsuarioDTO = usuarioDto;
    }

}




}
