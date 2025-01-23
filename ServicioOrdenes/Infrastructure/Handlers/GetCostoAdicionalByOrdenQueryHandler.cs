using MediatR;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetCostosAdicionalesByOrdenQueryHandler : IRequestHandler<GetCostosAdicionalesByOrdenQuery, List<CostoAdicionalOrdenDTO>>
{
    private readonly ICostoAdicionalRepository _repository;

    public GetCostosAdicionalesByOrdenQueryHandler(ICostoAdicionalRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CostoAdicionalOrdenDTO>> Handle(GetCostosAdicionalesByOrdenQuery request, CancellationToken cancellationToken)
    {
        var costos = await _repository.GetByOrdenIdAsync(request.OrdenId);

        if (!costos.Any())
        {
            throw new KeyNotFoundException($"No se encontraron costos adicionales para la orden con ID {request.OrdenId}");
        }

        return costos.Select(c => new CostoAdicionalOrdenDTO
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Monto = c.Monto
        }).ToList();
    }
}
