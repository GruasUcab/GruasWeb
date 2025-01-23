namespace GrúasUCAB.Core.Proveedores.DTO;

public class UpdateVehiculoDTO
{
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public required string Placa { get; set; }
    public int Capacidad { get; set; }
    public bool Activo { get; set; }
}
