using MediatR;
using GrúasUCAB.Core.Proveedores.Queries;
using GrúasUCAB.Core.Proveedores.Dto;
using GrúasUCAB.Core.Proveedores.Repositories;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores{

public class GetAllConductoresQueryHandler : IRequestHandler<GetAllConductoresQuery, IEnumerable<ConductorDTO>>
{
    private readonly IConductorRepository _repository;

    public GetAllConductoresQueryHandler(IConductorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ConductorDTO>> Handle(GetAllConductoresQuery request, CancellationToken cancellationToken)
    {
        var conductores = await _repository.GetAllAsync();
        return conductores.Select(c => new ConductorDTO
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Apellido = c.Apellido,
            Licencia = c.Licencia,
            ProveedorId = c.ProveedorId,
            Longitud = c.Longitud?? string.Empty,
            Latitud = c.Latitud?? string.Empty
        });
    }
}

}