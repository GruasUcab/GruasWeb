using MediatR;
using GrúasUCAB.Core.Proveedores.Commands;
using GrúasUCAB.Core.Proveedores.Repositories;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
    public class DeleteVehiculoCommandHandler : IRequestHandler<DeleteVehiculoCommand,Unit>
{
    private readonly IVehiculoRepository _repository;

    public DeleteVehiculoCommandHandler(IVehiculoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteVehiculoCommand request, CancellationToken cancellationToken)
    {
        var vehiculo = await _repository.GetByIdAsync(request.Id);
        if (vehiculo == null) throw new Exception("Vehículo no encontrado.");

        await _repository.DeleteAsync(vehiculo);
        return Unit.Value;
    }
}


}