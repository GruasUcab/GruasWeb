
namespace GrúasUCAB.Core.Ordenes.Services.interfaces{

public interface IProveedorService
{
    Task<Proveedor?> GetProveedorByIdAsync(Guid proveedorId);
}
}