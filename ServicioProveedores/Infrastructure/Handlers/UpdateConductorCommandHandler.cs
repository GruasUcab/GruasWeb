using MediatR;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Commands;
using GrúasUCAB.Core.Proveedores.Entities;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
public class UpdateConductorCommandHandler : IRequestHandler<UpdateConductorCommand, Unit>
{
    private readonly IConductorRepository _repository;

    public UpdateConductorCommandHandler(IConductorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateConductorCommand request, CancellationToken cancellationToken)
    {
        var conductor = await _repository.GetByIdAsync(request.ConductorDTO.Id);
        if (conductor == null)
        {
            throw new KeyNotFoundException("Conductor not found");
        }

        conductor.Update(
            request.ConductorDTO.Nombre,
            request.ConductorDTO.Apellido,
            request.ConductorDTO.Licencia,
            request.ConductorDTO.ProveedorId);

        await _repository.UpdateAsync(conductor);

        return Unit.Value;
    }
}

}