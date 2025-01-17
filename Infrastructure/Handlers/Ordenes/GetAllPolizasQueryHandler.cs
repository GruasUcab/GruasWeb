using MediatR;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Queries;

public class GetAllPolizasQueryHandler : IRequestHandler<GetAllPolizasQuery, IEnumerable<PolizaDTO>>
{
    private readonly IPolizaRepository _repository;

    public GetAllPolizasQueryHandler(IPolizaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PolizaDTO>> Handle(GetAllPolizasQuery request, CancellationToken cancellationToken)
    {
        var polizas = await _repository.GetAllAsync();

        return polizas.Select(poliza => new PolizaDTO
        {
            Id = poliza.Id,
            TipoCobertura = poliza.TipoCobertura,
            KilometrosIncluidos = poliza.KilometrosIncluidos,
            Nombre = poliza.Nombre,
            CostoXKilometro = poliza.CostoXKilometro
        });
    }
}
