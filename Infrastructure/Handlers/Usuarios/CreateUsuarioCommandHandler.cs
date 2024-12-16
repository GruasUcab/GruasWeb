using MediatR;
using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Core.Usuarios.Commands;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, Guid>
    {
        private readonly IUsuarioRepository _repository;

        public CreateUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(
                Guid.NewGuid(),
                request.Nombre,
                request.Apellido,
                request.Email,
                request.Clave,
                request.Activo,
                request.TipoUsuario,
                request.DepartamentoId
            );

            await _repository.AddAsync(usuario);
            await _repository.SaveChangesAsync();
            return usuario.Id;
        }
    }
}
