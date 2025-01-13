using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Core.Usuarios.DTOs;
using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Keycloak;
using MediatR;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Unit>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IKeycloakService _keycloakService;

    public UpdateUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IKeycloakService keycloakService)
    {
        _usuarioRepository = usuarioRepository;
        _keycloakService = keycloakService;
    }

    public async Task<Unit> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(request.Id);
        if (usuario == null)
        {
            throw new KeyNotFoundException("Usuario no encontrado.");
        }

        // Actualizar datos en Keycloak
        await _keycloakService.UpdateUserAsync(usuario.Sub, $"{request.Nombre}.{request.Apellido}@example.com", request.Nombre, request.Apellido, request.Activo);

        // Actualizar datos en la base de datos
        usuario = new Usuario(usuario.Id, request.Nombre, request.Apellido, request.DepartamentoId, request.Activo, usuario.Sub, usuario.Rol);
        await _usuarioRepository.UpdateAsync(usuario);

        return Unit.Value;
    }
}




}
