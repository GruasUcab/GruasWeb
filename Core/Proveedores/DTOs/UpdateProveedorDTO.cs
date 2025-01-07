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
    public Guid Id { get; set; } // Identificador único del proveedor
    public string Nombre { get; set; } = string.Empty; // Nombre del proveedor
    public string Direccion { get; set; } = string.Empty; // Dirección del proveedor
    public string Telefono { get; set; } = string.Empty; // Teléfono de contacto del proveedor
}


}
