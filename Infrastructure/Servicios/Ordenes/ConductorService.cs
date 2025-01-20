/*using GrúasUCAB.Core.Proveedores.Dto;
using GrúasUCAB.Core.Ordenes.Services.interfaces;
using GrúasUCAB.Infrastructure.Persistence.Proveedores;
using Microsoft.EntityFrameworkCore;

public class ConductorService : IConductorService
{
    private readonly ProveedorDbContext _dbContext;

    public ConductorService(ProveedorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ConductorDTO?> GetConductorByIdAsync(Guid conductorId)
    {
        var conductor = await _dbContext.Conductores
            .FirstOrDefaultAsync(c => c.Id == conductorId);

        return conductor == null ? null : new ConductorDTO
        {
            Id = conductor.Id,
            Nombre = conductor.Nombre,
            Apellido = conductor.Apellido,
            Licencia = conductor.Licencia
        };
    }
}*/
