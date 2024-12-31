using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Core.Usuarios.DTOs;
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
        var usuario = await _repository.GetByIdAsync(request.Id);

        if (usuario == null)
            throw new KeyNotFoundException($"Usuario with Id {request.Id} not found.");

        usuario.UpdateNombre(request.UsuarioDto.Nombre);
        usuario.UpdateApellido(request.UsuarioDto.Apellido);
        usuario.UpdateEmail(request.UsuarioDto.Email);
        usuario.UpdateClave(request.UsuarioDto.Clave);
        usuario.UpdateActivo(request.UsuarioDto.Activo);
        usuario.UpdateTipoUsuario(request.UsuarioDto.TipoUsuario);
        usuario.UpdateDepartamento(request.UsuarioDto.DepartamentoId);


        await _repository.UpdateAsync(usuario);
        return Unit.Value;
    }
}

}
