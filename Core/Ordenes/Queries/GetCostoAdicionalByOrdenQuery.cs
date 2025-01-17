using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;


public class GetCostosAdicionalesByOrdenQuery : IRequest<List<CostoAdicionalOrdenDTO>>
{
    public Guid OrdenId { get; set; }

    public GetCostosAdicionalesByOrdenQuery(Guid ordenId)
    {
        OrdenId = ordenId;
    }
}
