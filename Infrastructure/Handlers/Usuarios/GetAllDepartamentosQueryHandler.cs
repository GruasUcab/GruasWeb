using GrúasUCAB.Core.Usuarios.Dto;
using GrúasUCAB.Core.Usuarios.Queries;
using GrúasUCAB.Infrastructure.Persistence.Usuarios;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class GetAllDepartamentosQueryHandler : IRequestHandler<GetAllDepartamentosQuery, IEnumerable<DepartamentoDto>>
    {
        private readonly UsuarioDbContext _context;

        public GetAllDepartamentosQueryHandler(UsuarioDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartamentoDto>> Handle(GetAllDepartamentosQuery request, CancellationToken cancellationToken)
        {
            var departamentos = _context.Departamentos
                .Select(d => new DepartamentoDto
                {
                    Id = d.Id,
                    Nombre = d.Nombre,
                    Ubicacion = d.Ubicacion
                })
                .ToList();

            return await Task.FromResult(departamentos);
        }
    }
}
