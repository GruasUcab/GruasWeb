using System;
using System.Threading.Tasks;
using GrúasUCAB.Core.Ordenes.Services.interfaces;
using GrúasUCAB.Infrastructure.Persistence.Proveedores;
using Microsoft.EntityFrameworkCore;

public class ProveedorService : IProveedorService
{
    private readonly ProveedorDbContext _dbContext;

    public ProveedorService(ProveedorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Proveedor?> GetProveedorByIdAsync(Guid proveedorId)
    {
        return await _dbContext.Proveedores
            .FirstOrDefaultAsync(p => p.Id == proveedorId);
    }
}
