using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class UpdateOrdenDeServicioCommandHandler : IRequestHandler<UpdateOrdenDeServicioCommand, Unit>
{
    private readonly IOrdenDeServicioRepository _repository;

    public UpdateOrdenDeServicioCommandHandler(IOrdenDeServicioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateOrdenDeServicioCommand request, CancellationToken cancellationToken)
    {
        var dto = request.OrdenDeServicioDTO;
        var orden = await _repository.GetByIdAsync(dto.Id);

        if (orden == null)
        {
            throw new InvalidOperationException("Orden de servicio no encontrada");
        }

        orden.UpdateEstado(dto.Estado);
        orden.UpdateKilometrosRecorridos(dto.KilometrosRecorridos);
        orden.UpdateCostoTotal(dto.CostoTotal);
        orden.UpdateCostoBase(dto.CostoBase);

        await _repository.UpdateAsync(orden);
        return Unit.Value;
    }
}
