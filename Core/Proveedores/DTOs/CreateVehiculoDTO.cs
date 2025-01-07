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
public class VehiculoDTO
{
    public Guid Id { get; set; } // Identificador único del vehículo
    public string Marca { get; set; } = string.Empty; // Marca del vehículo
    public string Modelo { get; set; } = string.Empty; // Modelo del vehículo
    public string Placa { get; set; } = string.Empty; // Placa del vehículo
    public int Capacidad { get; set; } // Capacidad del vehículo (en toneladas, por ejemplo)
    public bool Activo { get; set; } // Indica si el vehículo está activo o no
}


}