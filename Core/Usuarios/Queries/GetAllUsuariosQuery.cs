using MediatR;
using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.DTOs;

namespace GrúasUCAB.Core.Usuarios.Queries
{
    public class GetAllUsuariosQuery : IRequest<IEnumerable<Usuario>>
{
}
}

