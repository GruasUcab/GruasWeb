using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Repositories;
using MediatR;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _repository;

        public UpdateUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.GetByIdAsync(request.UsuarioDTO.Id);

            if (usuario == null)
                throw new KeyNotFoundException("Usuario no encontrado.");               

                usuario.UpdateNombre(request.UsuarioDTO.Nombre) ;       
                usuario.UpdateApellido(request.UsuarioDTO.Apellido);
                usuario.UpdateActivo(request.UsuarioDTO.Activo);
                usuario.UpdateDepartamento(request.UsuarioDTO.DepartamentoId);                
                

            await _repository.UpdateAsync(usuario);
            return Unit.Value;
        }
    }
}
