using GrúasUCAB.Core.Proveedores.Queries;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Dto;
using MediatR;
using AutoMapper;
using GrúasUCAB.Core.Proveedores.DTO;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
    public class GetVehiculosByProveedorQueryHandler : IRequestHandler<GetVehiculosByProveedorQuery, IEnumerable<CreateVehiculoDTO>>
{
    private readonly IVehiculoRepository _repository;
    private readonly IMapper _mapper;

    public GetVehiculosByProveedorQueryHandler(IVehiculoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CreateVehiculoDTO>> Handle(GetVehiculosByProveedorQuery request, CancellationToken cancellationToken)
    {
        var vehiculos = await _repository.GetAllByProveedorIdAsync(request.ProveedorId);
        if (!vehiculos.Any()) throw new KeyNotFoundException("No se encontraron vehículos para el proveedor especificado.");

        return _mapper.Map<IEnumerable<CreateVehiculoDTO>>(vehiculos);
    }
}

}