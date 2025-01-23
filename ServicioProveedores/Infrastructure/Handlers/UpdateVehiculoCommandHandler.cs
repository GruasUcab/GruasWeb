using MediatR;
using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Commands;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
public class UpdateVehiculoCommandHandler : IRequestHandler<UpdateVehiculoCommand, Unit>
{
    private readonly IVehiculoRepository _repository;

    public UpdateVehiculoCommandHandler(IVehiculoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateVehiculoCommand request, CancellationToken cancellationToken)
    {
        var vehiculo = await _repository.GetByIdAsync(request.Id);
        if (vehiculo == null) throw new Exception("Vehículo no encontrado.");

        vehiculo.Update(
            request.VehiculoDTO.Modelo,
            request.VehiculoDTO.Placa,
            request.VehiculoDTO.Capacidad,
            request.VehiculoDTO.Activo,
            request.VehiculoDTO.Marca
        );

        await _repository.UpdateAsync(vehiculo);
        return Unit.Value;
    }
    }

}