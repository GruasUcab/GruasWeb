using MediatR;
using System.Collections.Generic;
using GrúasUCAB.Core.Usuarios.DTOs;

namespace GrúasUCAB.Core.Usuarios.Queries
{
    public class GetAllUsuariosQuery : IRequest<IEnumerable<UsuarioResponseDTO>>
    {
    }
}
