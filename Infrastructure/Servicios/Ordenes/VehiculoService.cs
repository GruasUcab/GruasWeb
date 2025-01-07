using System;
using System.Threading.Tasks;
using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Infrastructure.Persistence.Proveedores;
using Microsoft.EntityFrameworkCore;
using GrúasUCAB.Core.Ordenes.Services.interfaces;

public class VehiculoService : IVehiculoService
{
    private readonly ProveedorDbContext _dbContext;

    public VehiculoService(ProveedorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Vehiculo?> GetVehiculoByIdAsync(Guid vehiculoId)
    {
        return await _dbContext.Vehiculos
            .FirstOrDefaultAsync(v => v.Id == vehiculoId);
    }
}
