using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;


namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

public class UpdateVehiculoAseguradoCommandHandler : IRequestHandler<UpdateVehiculoAseguradoCommand, Unit>
{
    private readonly IVehiculoAseguradoRepository _repository;

    public UpdateVehiculoAseguradoCommandHandler(IVehiculoAseguradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateVehiculoAseguradoCommand request, CancellationToken cancellationToken)
    {
        var vehiculoAsegurado = await _repository.GetByIdAsync(request.Id);
        if (vehiculoAsegurado == null)
            throw new KeyNotFoundException("Vehiculo no encontrado");

        vehiculoAsegurado.Update(request.VehiculoAseguradoDTO.Placa, request.VehiculoAseguradoDTO.Marca, request.VehiculoAseguradoDTO.Modelo, request.VehiculoAseguradoDTO.Tipo, request.VehiculoAseguradoDTO.PolizaId);
        await _repository.UpdateAsync(vehiculoAsegurado);
        await _repository.SaveChangesAsync();
        return Unit.Value;
    }
}

}