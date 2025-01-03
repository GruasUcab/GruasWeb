using MediatR;
using GrúasUCAB.Core.Proveedores.Commands;
using GrúasUCAB.Core.Proveedores.Repositories;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
   public class DeleteProveedorCommandHandler : IRequestHandler<DeleteProveedorCommand, Unit>
{
    private readonly IProveedorRepository _repository;

    public DeleteProveedorCommandHandler(IProveedorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteProveedorCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}


}
