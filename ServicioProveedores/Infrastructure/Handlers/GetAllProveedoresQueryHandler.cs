using AutoMapper;
using MediatR;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Queries;
using GrúasUCAB.Core.Proveedores.Dto;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores{
public class GetAllProveedoresQueryHandler : IRequestHandler<GetAllProveedoresQuery, IEnumerable<ProveedorDTO>>
{
    private readonly IProveedorRepository _repository;
    private readonly IMapper _mapper;

    public GetAllProveedoresQueryHandler(IProveedorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProveedorDTO>> Handle(GetAllProveedoresQuery request, CancellationToken cancellationToken)
    {
        var proveedores = await _repository.GetAllAsync();
        return proveedores.Select(v => new ProveedorDTO{
            Id = v.Id,
            Nombre = v.Nombre,
            Direccion = v.Direccion,
            Telefono = v.Telefono
        });
    }
}
}

