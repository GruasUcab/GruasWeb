using MediatR;
using GrúasUCAB.Core.Proveedores.Queries;
using GrúasUCAB.Core.Proveedores.Dto;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.DTO;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores{

public class GetAllVehiculosQueryHandler : IRequestHandler<GetAllVehiculosQuery, IEnumerable<VehiculoDTO>>
{
    private readonly IVehiculoRepository _repository;

    public GetAllVehiculosQueryHandler(IVehiculoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VehiculoDTO>> Handle(GetAllVehiculosQuery request, CancellationToken cancellationToken)
    {
        var vehiculos = await _repository.GetAllAsync();

        return vehiculos.Select(v => new VehiculoDTO
        {
            Id = v.Id,
            Marca = v.Marca?? "",
            Modelo = v.Modelo?? "",
            Placa = v.Placa?? "",            
            Capacidad = v.Capacidad,
            Activo = v.Activo
        });
    }
}


}