using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Queries{

    public class GetOrdenesByConductorIdQuery : IRequest<IEnumerable<OrdenDeServicioDTO>>
{
    public Guid ConductorId { get; set; }

    public GetOrdenesByConductorIdQuery(Guid conductorId)
    {
        ConductorId = conductorId;
    }
}


}