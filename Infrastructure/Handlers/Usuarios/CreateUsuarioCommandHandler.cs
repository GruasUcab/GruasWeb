using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.DTOs;
using GrúasUCAB.Core.Usuarios.Repositories;
using MediatR;
using GrúasUCAB.Core.Usuarios.Entities;

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
            request.UsuarioDto.Nombre,
            request.UsuarioDto.Apellido,
            request.UsuarioDto.Email,
            request.UsuarioDto.Clave,
            request.UsuarioDto.Activo,
            request.UsuarioDto.TipoUsuario,
            request.UsuarioDto.DepartamentoId
        );

        await _repository.CreateAsync(usuario);
        return usuario.Id;
    }
}

}
