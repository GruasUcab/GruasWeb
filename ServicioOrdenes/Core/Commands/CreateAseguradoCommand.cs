using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{

    public class CreateAseguradoCommand : IRequest<Guid>
{
    public required CreateAseguradoDTO AseguradoDto { get; set; }
}
}