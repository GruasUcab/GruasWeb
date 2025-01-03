namespace GrúasUCAB.Core.Proveedores.Dto
{
    public class UpdateProveedorDTO
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; } = string.Empty;
    public required string Direccion { get; set; } = string.Empty;
    public required string Telefono { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required bool Activo {get; set; } = false;
    public required string Tipo {get; set; } = string.Empty;
    public required Proveedor proveedor {get; set; }
}

public class ProveedorDTO
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public required string Direccion { get; set; }
    public required string Telefono { get; set; }
}


}
