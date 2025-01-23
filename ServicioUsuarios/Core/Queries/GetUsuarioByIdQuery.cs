using GrúasUCAB.Core.Usuarios.Entities;
using MediatR;

namespace GrúasUCAB.Core.Usuarios.Queries{

    public class GetUsuarioByIdQuery : IRequest<Usuario?>
{
    public Guid Id { get; set; }
}

}
