namespace GrúasUCAB.Core.Proveedores.DTO
{
public class CreateVehiculoDTO
{
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public required string Placa { get; set; }
    public Guid ProveedorId { get; set; }
    public int Capacidad { get; set; }
    public bool Activo { get; set; }
}
}