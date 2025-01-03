namespace GrúasUCAB.Core.Proveedores.Dto{
public class CreateConductorDTO
{
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Licencia { get; set; }
    public required int Telefono {get; set; }
    public required bool Activo {get; set;}
    public Guid ProveedorId { get; set; }
}

public class UpdateConductorDTO
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Licencia { get; set; }
    public Guid ProveedorId { get; set; }
}

public class ConductorDTO
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Licencia { get; set; }
    public Guid ProveedorId { get; set; }
}


}