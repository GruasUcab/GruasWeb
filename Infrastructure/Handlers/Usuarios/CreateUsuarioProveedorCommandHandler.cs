using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Infrastructure.Auth;
using GrúasUCAB.Core.Keycloak; 
using MediatR;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class CreateUsuarioProveedorCommandHandler : IRequestHandler<CreateUsuarioProveedorCommand, Guid>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IKeycloakService _keycloakService;

        public CreateUsuarioProveedorCommandHandler(IUsuarioRepository repository, IKeycloakService keycloakService)
        {
            _repository = repository;
            _keycloakService = keycloakService;
        }

        public async Task<Guid> Handle(CreateUsuarioProveedorCommand request, CancellationToken cancellationToken)
        {
            // Crear el usuario en Keycloak
            var defaultRole = "Proveedor";
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
                null,                           
                request.UsuarioDto.Activo,
                keycloakSub,                
                request.UsuarioDto.ProveeId
            );

            await _repository.AddAsync(usuario);   

            return usuario.Id;
        }
    }
}
