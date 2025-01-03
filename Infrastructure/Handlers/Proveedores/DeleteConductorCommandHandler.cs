using MediatR;
using GrúasUCAB.Core.Proveedores.Commands;
using GrúasUCAB.Core.Proveedores.Repositories;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
   public class DeleteConductorCommandHandler : IRequestHandler<DeleteConductorCommand, Unit>
{
    private readonly IConductorRepository _repository;

    public DeleteConductorCommandHandler(IConductorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteConductorCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
} 
}
