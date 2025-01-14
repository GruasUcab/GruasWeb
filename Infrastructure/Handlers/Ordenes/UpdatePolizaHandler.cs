using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Entities;

public class UpdatePolizaCommandHandler : IRequestHandler<UpdatePolizaCommand, Unit>
{
    private readonly IPolizaRepository _repository;

    public UpdatePolizaCommandHandler(IPolizaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdatePolizaCommand request, CancellationToken cancellationToken)
    {
        var poliza = await _repository.GetByIdAsync(request.Id);
        if (poliza == null) throw new KeyNotFoundException("Poliza not found");

        poliza.Actualizar(request.PolizaDTO.TipoCobertura, request.PolizaDTO.KilometrosIncluidos, request.PolizaDTO.CostoXKilometro);
        await _repository.UpdateAsync(poliza);

        return Unit.Value;
    }
}