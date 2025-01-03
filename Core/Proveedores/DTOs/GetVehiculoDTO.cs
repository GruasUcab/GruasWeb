namespace GrúasUCAB.Core.Proveedores.Dto{
public class GetVehiculoDTO
{
    public Guid Id { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? Placa { get; set; }
    public Guid ProveedorId { get; set; }
    public int Capacidad { get; set; }
    public bool Activo { get; set; }
    public required string ProveedorNombre { get; set; }
}


}