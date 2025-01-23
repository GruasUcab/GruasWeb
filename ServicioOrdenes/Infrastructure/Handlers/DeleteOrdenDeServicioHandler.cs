using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class DeleteOrdenDeServicioCommandHandler : IRequestHandler<DeleteOrdenDeServicioCommand, Unit>
{
    private readonly IOrdenDeServicioRepository _repository;

    public DeleteOrdenDeServicioCommandHandler(IOrdenDeServicioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteOrdenDeServicioCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
