using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

public class CreateVehiculoAseguradoCommandHandler : IRequestHandler<CreateVehiculoAseguradoCommand, Guid>
{
    private readonly IVehiculoAseguradoRepository _repository;

    public CreateVehiculoAseguradoCommandHandler(IVehiculoAseguradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateVehiculoAseguradoCommand request, CancellationToken cancellationToken)
    {
        var vehiculoAsegurado = new VehiculoAsegurado(Guid.NewGuid(), request.VehiculoAseguradoDTO.Placa, request.VehiculoAseguradoDTO.Marca, request.VehiculoAseguradoDTO.Modelo, request.VehiculoAseguradoDTO.Tipo, request.VehiculoAseguradoDTO.AseguradoId, request.VehiculoAseguradoDTO.PolizaId);
        await _repository.AddAsync(vehiculoAsegurado);
        await _repository.SaveChangesAsync();
        return vehiculoAsegurado.Id;
    }
}

}


