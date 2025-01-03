using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Infrastructure.Handlers{
public class CreatePolizaCommandHandler : IRequestHandler<CreatePolizaCommand, Guid>
{
    private readonly IPolizaRepository _repository;

    public CreatePolizaCommandHandler(IPolizaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreatePolizaCommand request, CancellationToken cancellationToken)
    {
        var poliza = new Poliza(Guid.NewGuid(), request.PolizaDTO.TipoCobertura, request.PolizaDTO.KilometrosIncluidos);
        await _repository.AddAsync(poliza);
        return poliza.Id;
    }
}




}