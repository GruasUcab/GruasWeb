using MediatR;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Commands;

namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{
public class DeleteCostoAdicionalCommandHandler : IRequestHandler<DeleteCostoAdicionalCommand, Unit>
{
    private readonly ICostoAdicionalRepository _repository;

    public DeleteCostoAdicionalCommandHandler(ICostoAdicionalRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteCostoAdicionalCommand request, CancellationToken cancellationToken)
    {
        var costoAdicional = await _repository.GetByIdAsync(request.Id);
        if (costoAdicional == null)
        {
            throw new KeyNotFoundException("El costo adicional no existe.");
        }

        await _repository.DeleteAsync(costoAdicional);
        await _repository.SaveChangesAsync();

        return Unit.Value;
    }
}
}
