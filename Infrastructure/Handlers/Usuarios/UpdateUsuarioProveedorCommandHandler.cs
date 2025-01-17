using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Repositories;
using MediatR;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class UpdateUsuarioProveedorCommandHandler : IRequestHandler<UpdateUsuarioProveedorCommand, Unit>
    {
        private readonly IUsuarioRepository _repository;

        public UpdateUsuarioProveedorCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUsuarioProveedorCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.GetByIdAsync(request.UsuarioDTO.Id);

            if (usuario == null)
                throw new KeyNotFoundException("Usuario no encontrado.");               

                usuario.UpdateNombre(request.UsuarioDTO.Nombre) ;       
                usuario.UpdateApellido(request.UsuarioDTO.Apellido);
                usuario.UpdateActivo(request.UsuarioDTO.Activo);
                usuario.UpdateProveedor(request.UsuarioDTO.ProveedorId);
                usuario.UpdateRol(request.UsuarioDTO.Roles);
   
                

            await _repository.UpdateAsync(usuario);
            return Unit.Value;
        }
    }
}
