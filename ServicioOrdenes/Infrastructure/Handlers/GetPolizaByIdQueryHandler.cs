using MediatR;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.DTOs;
using System.Threading;
using System.Threading.Tasks;

public class GetPolizaByIdQueryHandler : IRequestHandler<GetPolizaByIdQuery, PolizaDTO>
{
    private readonly IPolizaRepository _repository;

    public GetPolizaByIdQueryHandler(IPolizaRepository repository)
    {
        _repository = repository;
    }

    public async Task<PolizaDTO> Handle(GetPolizaByIdQuery request, CancellationToken cancellationToken)
    {
        var poliza = await _repository.GetByIdAsync(request.Id);

        if (poliza == null)
        {
            throw new KeyNotFoundException($"No se encontró una póliza con el ID {request.Id}");
        }

        return new PolizaDTO
        {
            Id = poliza.Id,
            TipoCobertura = poliza.TipoCobertura,
            KilometrosIncluidos = poliza.KilometrosIncluidos,
            Nombre = poliza.Nombre,
            CostoXKilometro = poliza.CostoXKilometro
        };
    }
}
