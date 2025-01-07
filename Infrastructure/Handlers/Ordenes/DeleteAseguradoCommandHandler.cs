using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;


namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

    public class DeleteAseguradoCommandHandler : IRequestHandler<DeleteAseguradoCommand, Unit>
{
    private readonly IAseguradoRepository _repository;

    public DeleteAseguradoCommandHandler(IAseguradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteAseguradoCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        await _repository.SaveChangesAsync();
        return Unit.Value;
    }
}
}