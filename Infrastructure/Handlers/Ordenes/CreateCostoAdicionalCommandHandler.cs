using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{
public class CreateCostoAdicionalCommandHandler : IRequestHandler<CreateCostoAdicionalCommand, Guid>
{
    private readonly ICostoAdicionalRepository _repository;

    public CreateCostoAdicionalCommandHandler(ICostoAdicionalRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateCostoAdicionalCommand request, CancellationToken cancellationToken)
    {
        var costoAdicional = new CostoAdicional(Guid.NewGuid(), request.Nombre, request.Descripcion, request.Monto, request.OrdenId);
        await _repository.AddAsync(costoAdicional);
        await _repository.SaveChangesAsync();

        return costoAdicional.Id;
    }
}
}