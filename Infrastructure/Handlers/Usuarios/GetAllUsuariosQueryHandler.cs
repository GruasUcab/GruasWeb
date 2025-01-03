using GrúasUCAB.Core.Usuarios.Queries;
using GrúasUCAB.Infrastructure.Persistence.Usuarios;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, IEnumerable<UsuarioResponseDTO>>
    {
        private readonly UsuarioDbContext _context;

        public GetAllUsuariosQueryHandler(UsuarioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioResponseDTO>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = _context.Usuarios
                .Select(u => new UsuarioResponseDTO
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Activo = u.Activo,
                    TipoUsuario = u.TipoUsuario
                })
                .ToList();

            return await Task.FromResult(usuarios);
        }
    }
}
