using GrúasUCAB.Core.Proveedores.Queries;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Dto;
using MediatR;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores{

    public class GetVehiculoByIdQueryHandler : IRequestHandler<GetVehiculoByIdQuery, GetVehiculoDTO>
{
    private readonly IVehiculoRepository _repository;

    public GetVehiculoByIdQueryHandler(IVehiculoRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetVehiculoDTO> Handle(GetVehiculoByIdQuery request, CancellationToken cancellationToken)
    {
        var vehiculo = await _repository.GetByIdAsync(request.Id);
        if (vehiculo == null)
        {
            throw new Exception("Vehículo no encontrado.");
        }

        return new GetVehiculoDTO
        {
            Id = vehiculo.Id,
            Marca = vehiculo.Marca,
            Modelo = vehiculo.Modelo,
            Placa = vehiculo.Placa,
            ProveedorId = vehiculo.ProveedorId,
            Capacidad = vehiculo.Capacidad,
            Activo = vehiculo.Activo,
            ProveedorNombre = vehiculo.Proveedor.Nombre
        };
    }
}

}