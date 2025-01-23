using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Entities;

public class DeletePolizaCommandHandler : IRequestHandler<DeletePolizaCommand, Unit>
{
    private readonly IPolizaRepository _repository;

    public DeletePolizaCommandHandler(IPolizaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeletePolizaCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}