namespace GrúasUCAB.Core.Ordenes.DTOs{

public class CreateOrdenDeServicioDTO
{
    public DateTime FechaCreacion { get; set; }
    public required string Estado { get; set; }
    public required string UbicacionIncidente { get; set; }
    public required string UbicacionDestino { get; set; }
    public decimal KilometrosRecorridos { get; set; }
    public decimal CostoTotal { get; set; }
    public Guid? ConductorId { get; set; }
    public Guid? ProveedorId { get; set; }
    public Guid? VehiculoId { get; set; }
}




public class UpdateOrdenDeServicioDTO
{
    public Guid Id { get; set; }
    public required string Estado { get; set; }
    public decimal KilometrosRecorridos { get; set; }
    public decimal CostoTotal { get; set; }
}


public class OrdenDeServicioDTO
{
    public Guid Id { get; set; }
    public DateTime FechaCreacion { get; set; }
    public required string Estado { get; set; }
    public required string UbicacionIncidente { get; set; }
    public required string UbicacionDestino { get; set; }
    public decimal KilometrosRecorridos { get; set; }
    public decimal CostoTotal { get; set; }
    public Guid? ConductorId { get; set; }
    public Guid? ProveedorId { get; set; }
    public Guid? VehiculoId { get; set; }
    
}



}