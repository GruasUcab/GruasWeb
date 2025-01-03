using MediatR;
using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Commands;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores{
public class CreateVehiculoCommandHandler : IRequestHandler<CreateVehiculoCommand, Guid>
{
    private readonly IVehiculoRepository _repository;
    private readonly IProveedorRepository _proveedorRepository;

    public CreateVehiculoCommandHandler(IVehiculoRepository repository, IProveedorRepository proveedorRepository)
    {
        _repository = repository;
        _proveedorRepository = proveedorRepository;
    }

    public async Task<Guid> Handle(CreateVehiculoCommand request, CancellationToken cancellationToken)
    {
        var proveedor = await _proveedorRepository.GetByIdAsync(request.VehiculoDTO.ProveedorId);
        if (proveedor == null) throw new Exception("Proveedor no encontrado.");

        var vehiculo = new Vehiculo(
            Guid.NewGuid(),
            request.VehiculoDTO.Marca,
            request.VehiculoDTO.Modelo,
            request.VehiculoDTO.Placa,
            request.VehiculoDTO.ProveedorId,
            request.VehiculoDTO.Capacidad,
            request.VehiculoDTO.Activo
        );

        await _repository.AddAsync(vehiculo);
        return vehiculo.Id;
    }
}

}
