using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Queries;
using GrúasUCAB.Core.Ordenes.Repositories;

namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

    public class GetAllVehiculosAseguradosQueryHandler : IRequestHandler<GetAllVehiculosAseguradosQuery, IEnumerable<CreateVehiculoAseguradoDTO>>
{
    private readonly IVehiculoAseguradoRepository _repository;

    public GetAllVehiculosAseguradosQueryHandler(IVehiculoAseguradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CreateVehiculoAseguradoDTO>> Handle(GetAllVehiculosAseguradosQuery request, CancellationToken cancellationToken)
    {
        var vehiculosAsegurados = await _repository.GetAllAsync();
        return vehiculosAsegurados.Select(a => new CreateVehiculoAseguradoDTO
        {
            Placa = a.Placa?? string.Empty,
            Marca = a.Marca?? string.Empty,
            Modelo = a.Modelo?? string.Empty,
            Tipo = a.Tipo?? string.Empty,
            AseguradoId = a.AseguradoId,
            PolizaId = a.PolizaId            
        });
    }
}
}