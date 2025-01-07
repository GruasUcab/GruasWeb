using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Queries{

    public class GetCostoAdicionalByIdQuery : IRequest<CostoAdicionalDTO>
{
    public Guid Id { get; set; }

    public GetCostoAdicionalByIdQuery(Guid id)
    {
        Id = id;
    }
}

}