using MediatR;
using GrúasUCAB.Core.Usuarios.Entities;


namespace GrúasUCAB.Core.Usuarios.Queries
{
    public class GetAllUsuariosQuery : IRequest<IEnumerable<Usuario>>
{
}
}

