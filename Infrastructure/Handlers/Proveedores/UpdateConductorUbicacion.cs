using MediatR;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Commands;
using GrúasUCAB.Core.Proveedores.Entities;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
public class UpdateConductorUbicacionCommandHandler : IRequestHandler<UpdateConductorUbicacionCommand, Unit>
{
    private readonly IConductorRepository _repository;

    public UpdateConductorUbicacionCommandHandler(IConductorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateConductorUbicacionCommand request, CancellationToken cancellationToken)
    {

        var conductor = await _repository.GetByIdAsync(request.Id);
        if (conductor == null)
        {
            throw new KeyNotFoundException("Conductor not found");
        }

        conductor.UpdateUbicacion(
            request.ConductorDTO.Latitud,
            request.ConductorDTO.Longitud);

        await _repository.UpdateAsync(conductor);

        return Unit.Value;
    }
}

}