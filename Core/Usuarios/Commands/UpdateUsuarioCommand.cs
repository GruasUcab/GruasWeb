using GrúasUCAB.Core.Usuarios.DTOs;
using MediatR;

namespace GrúasUCAB.Core.Usuarios.Commands
{
   public class UpdateUsuarioCommand : IRequest <Unit>
    {
        public Guid Id { get; set; }
        public UpdateUsuarioDTO UsuarioDto { get; set; }

        public UpdateUsuarioCommand(Guid id, UpdateUsuarioDTO usuarioDto)
        {
            Id = id;
            UsuarioDto = usuarioDto;
        }
    }

}
