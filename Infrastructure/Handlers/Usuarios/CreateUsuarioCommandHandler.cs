using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Infrastructure.Auth;
using GrúasUCAB.Core.Keycloak; 
using MediatR;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, Guid>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IKeycloakService _keycloakService;

        public CreateUsuarioCommandHandler(IUsuarioRepository repository, IKeycloakService keycloakService)
        {
            _repository = repository;
            _keycloakService = keycloakService;
        }

        public async Task<Guid> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            // Crear el usuario en Keycloak
            var defaultRole = "Operador";
            var keycloakSub = await _keycloakService.CreateUserWithRoleAsync(
                request.UsuarioDto.Username,
                request.UsuarioDto.Email,
                request.UsuarioDto.Nombre,
                request.UsuarioDto.Apellido,
                request.UsuarioDto.Password,
                new List<string> { defaultRole }


                
            );
            
            if (string.IsNullOrEmpty(keycloakSub))
            {
                throw new InvalidOperationException("No se pudo crear el usuario en Keycloak.");
            }

            

            // Crear el usuario en la base de datos local
            var usuario = new Usuario(
                Guid.NewGuid(),
                request.UsuarioDto.Nombre,
                request.UsuarioDto.Apellido,
                request.UsuarioDto.DepartamentoId,
                request.UsuarioDto.Activo,
                keycloakSub,                
                Guid.Empty
            );

            await _repository.AddAsync(usuario);   

            return usuario.Id;
        }
    }
}
