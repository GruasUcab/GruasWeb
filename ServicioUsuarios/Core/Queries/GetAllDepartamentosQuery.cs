using GrúasUCAB.Core.Usuarios.Dto;
using MediatR;
using System.Collections.Generic;

namespace GrúasUCAB.Core.Usuarios.Queries
{
    public class GetAllDepartamentosQuery : IRequest<IEnumerable<DepartamentoDto>>
    {
    }
}
