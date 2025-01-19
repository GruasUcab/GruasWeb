using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Queries{

    public class GetVehiculoAseguradoByIdQuery : IRequest<CreateVehiculoAseguradoDTO>
{
    public Guid Id { get; set; }
}
}