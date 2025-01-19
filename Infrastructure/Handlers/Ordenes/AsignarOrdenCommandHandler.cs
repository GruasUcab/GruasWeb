using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;


namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

    public class AsignarOrdenCommandHandler : IRequestHandler<AsignarOrdenCommand, Unit>
{
    private readonly IOrdenDeServicioRepository _repository;

    public AsignarOrdenCommandHandler(IOrdenDeServicioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(AsignarOrdenCommand request, CancellationToken cancellationToken)
    {
        var orden = await _repository.GetByIdAsync(request.OrdenId);

        if (orden == null)
        {
            throw new KeyNotFoundException("Orden no encontrada.");
        }

        //orden.Asignar();
        await _repository.UpdateAsync(orden);

        return Unit.Value;
    }
}

}