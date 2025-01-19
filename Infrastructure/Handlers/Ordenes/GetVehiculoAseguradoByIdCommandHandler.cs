using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Queries;
using GrúasUCAB.Core.Ordenes.Repositories;

namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

    public class GetVehiculoAseguradoByIdQueryHandler : IRequestHandler<GetVehiculoAseguradoByIdQuery, CreateVehiculoAseguradoDTO>
{
    private readonly IVehiculoAseguradoRepository _repository;

    public GetVehiculoAseguradoByIdQueryHandler(IVehiculoAseguradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateVehiculoAseguradoDTO> Handle(GetVehiculoAseguradoByIdQuery request, CancellationToken cancellationToken)
    {
        var vehiculoAsegurado = await _repository.GetByIdAsync(request.Id);
        if (vehiculoAsegurado == null)
            throw new KeyNotFoundException("Vehiculo no encontrado");

        return new CreateVehiculoAseguradoDTO
        {           
            Marca = vehiculoAsegurado.Marca?? string.Empty,
            Modelo = vehiculoAsegurado.Modelo?? string.Empty,
            Placa = vehiculoAsegurado.Placa?? string.Empty,
            Tipo = vehiculoAsegurado.Tipo?? string.Empty,
            AseguradoId = vehiculoAsegurado.AseguradoId

            
        };
    }
}
};
