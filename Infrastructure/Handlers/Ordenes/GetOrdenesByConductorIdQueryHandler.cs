using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Queries;
using GrúasUCAB.Infrastructure.Persistence.Ordenes;
using Microsoft.EntityFrameworkCore;



namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

    public class GetOrdenesByConductorIdQueryHandler : IRequestHandler<GetOrdenesByConductorIdQuery, IEnumerable<OrdenDeServicioDTO>>
{
    private readonly OrdenDbContext _context;

    public GetOrdenesByConductorIdQueryHandler(OrdenDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrdenDeServicioDTO>> Handle(GetOrdenesByConductorIdQuery request, CancellationToken cancellationToken)
    {
        var ordenes = await _context.OrdenesDeServicio
            .Where(o => o.ConductorId == request.ConductorId)
            .ToListAsync(cancellationToken); // Ejecuta la consulta en la base de datos

        // Proyección a DTO después de obtener los datos
        var ordenesDto = ordenes.Select(o => new OrdenDeServicioDTO
        {
            Id = o.Id,
            FechaCreacion = o.FechaCreacion,
            Estado = o.Estado,
            UbicacionIncidente = o.UbicacionIncidente?? "",
            UbicacionDestino = o.UbicacionDestino?? "",
            KilometrosRecorridos = o.KilometrosRecorridos,
            CostoTotal = o.CostoTotal,
            ConductorId = o.ConductorId,
            ProveedorId = o.ProveedorId,
            VehiculoId = o.VehiculoId
        });

        return ordenesDto;
    }
}

    
}