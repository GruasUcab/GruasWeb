using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

    public class UpdateCostoAdicionalCommandHandler : IRequestHandler<UpdateCostoAdicionalCommand, Unit>
{
    private readonly ICostoAdicionalRepository _repository;

    public UpdateCostoAdicionalCommandHandler(ICostoAdicionalRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateCostoAdicionalCommand request, CancellationToken cancellationToken)
    {
        var costoAdicional = await _repository.GetByIdAsync(request.Id);
        if (costoAdicional == null)
        {
            throw new KeyNotFoundException("El costo adicional no existe.");
        }

        costoAdicional.update(request.Id ,request.Nombre, request.Descripcion, request.Monto);
        await _repository.SaveChangesAsync();

        return Unit.Value;
    }
}

}