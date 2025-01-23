using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{

    public class UpdateAseguradoCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public required UpdateAseguradoDTO AseguradoDto { get; set; }
}
}
