namespace GrúasUCAB.Core.Ordenes.DTOs{
public class ConductorDTO
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Licencia { get; set; }
    public required string Sub {get; set;}
    public bool Activo{get; set;}
    public Guid ProveedorId { get; set; }
    public required string Latitud { get; set; }
    public required string Longitud { get; set; }
}
}