using MediatR;
using GrúasUCAB.Core.Usuarios.Dto;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Core.Usuarios.Queries;
using AutoMapper;

namespace GrúasUCAB.Infrastructure.Handlers{

    public class GetAllUsuariosProveedoresQueryHandler : IRequestHandler<GetAllUsuariosProveedoresQuery, IEnumerable<UsuarioDTO>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public GetAllUsuariosProveedoresQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<UsuarioDTO>> Handle(GetAllUsuariosProveedoresQuery request, CancellationToken cancellationToken)
    {
        var usuariosProveedores = await _usuarioRepository.GetAllAsync(u => u.ProveeId != Guid.Empty);

        return usuariosProveedores.Select(u => new UsuarioDTO
        {
            Id = u.Id,
            Nombre = u.Nombre,
            Apellido = u.Apellido,
            DepartamentoId = u.DepartamentoId,
            Activo = u.Activo,
            Sub = u.Sub,
            ProveeId = u.ProveeId
        });
    }
}


}