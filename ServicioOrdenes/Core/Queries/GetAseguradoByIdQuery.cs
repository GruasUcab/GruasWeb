using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Queries{

    public class GetAseguradoByIdQuery : IRequest<AseguradoDTO>
{
    public Guid Id { get; set; }
}
}