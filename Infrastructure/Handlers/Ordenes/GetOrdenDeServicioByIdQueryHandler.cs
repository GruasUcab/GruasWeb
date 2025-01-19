using AutoMapper;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Repositories;
using MediatR;
using GrúasUCAB.Core.Ordenes.Queries;
using System.Threading;
using System.Threading.Tasks;

/*public class GetOrdenDeServicioByIdQueryHandler : IRequestHandler<GetOrdenDeServicioByIdQuery, OrdenDeServicioDTO?>
{
    private readonly IOrdenDeServicioRepository _repository;
    private readonly IMapper _mapper;

    public GetOrdenDeServicioByIdQueryHandler(IOrdenDeServicioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<OrdenDeServicioDTO?> Handle(GetOrdenDeServicioByIdQuery request, CancellationToken cancellationToken)
    {
        var orden = await _repository.GetByIdAsync(request.Id);
        return orden == null ? null : _mapper.Map<OrdenDeServicioDTO>(orden);
    }
}*/

public class GetOrdenDeServicioByIdQueryHandler : IRequestHandler<GetOrdenDeServicioByIdQuery, OrdenDeServicioDTO>
{
    private readonly IOrdenDeServicioRepository _repository;

    public GetOrdenDeServicioByIdQueryHandler(IOrdenDeServicioRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrdenDeServicioDTO> Handle(GetOrdenDeServicioByIdQuery request, CancellationToken cancellationToken)
    {
        var orden = await _repository.GetByIdAsync(request.Id);

        if (orden == null)
        {
            throw new KeyNotFoundException($"La orden de servicio con ID {request.Id} no fue encontrada.");
        }

        // Mapear los datos de la orden a DTO
        var ordenDto = new OrdenDeServicioDTO
        {
            Id = orden.Id,
            FechaCreacion = orden.FechaCreacion,
            Estado = orden.Estado,
            UbicacionIncidente = orden.UbicacionIncidente?? "",
            UbicacionDestino = orden.UbicacionDestino?? "",
            KilometrosRecorridos = orden.KilometrosRecorridos?? 0,
            CostoTotal = orden.CostoTotal,
            ConductorId = orden.ConductorId,
            ProveedorId = orden.ProveedorId,
            VehiculoId = orden.VehiculoId
        };

        return ordenDto;
    }
};


