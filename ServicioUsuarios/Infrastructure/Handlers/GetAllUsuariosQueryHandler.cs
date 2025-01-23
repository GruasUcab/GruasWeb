using GrúasUCAB.Core.Usuarios.Queries;
using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Infrastructure.Persistence.Usuarios;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, IEnumerable<Usuario>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public GetAllUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<Usuario>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
    {
        return await _usuarioRepository.GetAllAsync();
    }
}

}
