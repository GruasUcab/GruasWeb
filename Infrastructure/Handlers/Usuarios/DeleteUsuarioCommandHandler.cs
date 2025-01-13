using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Repositories;
using Keycloak.Net.Models.Users;
using GrúasUCAB.Core.Keycloak;
using Microsoft.Extensions.Configuration;
using MediatR;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, Unit>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IKeycloakService _keycloakService;

    public DeleteUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IKeycloakService keycloakService)
    {
        _usuarioRepository = usuarioRepository;
        _keycloakService = keycloakService;
    }

    public async Task<Unit> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(request.Id);
        if (usuario == null)
        {
            throw new KeyNotFoundException("Usuario no encontrado.");
        }

        // Eliminar usuario de Keycloak
        await _keycloakService.DeleteUserAsync(usuario.Sub);

        // Eliminar usuario de la base de datos
        await _usuarioRepository.DeleteAsync(usuario);

        return Unit.Value;
    }
}





}
