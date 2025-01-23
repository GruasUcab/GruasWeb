using MediatR;  
using GrúasUCAB.Core.Usuarios.Dto;

namespace GrúasUCAB.Core.Usuarios.Queries{


    public record GetAllUsuariosProveedoresQuery : IRequest<IEnumerable<UsuarioDTO>>;

}