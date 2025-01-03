using MediatR;
using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Commands;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
    public class CreateConductorCommandHandler : IRequestHandler<CreateConductorCommand, Guid>
{
    private readonly IConductorRepository _repository;

    public CreateConductorCommandHandler(IConductorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateConductorCommand request, CancellationToken cancellationToken)
    {
        var conductor = new Conductor(
            Guid.NewGuid(),
            request.ConductorDTO.Nombre,
            request.ConductorDTO.Apellido,
            request.ConductorDTO.Licencia,
            request.ConductorDTO.ProveedorId);

        await _repository.AddAsync(conductor);

        return conductor.Id;
    }
}
}