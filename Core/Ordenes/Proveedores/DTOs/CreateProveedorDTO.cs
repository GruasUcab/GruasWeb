namespace GrúasUCAB.Core.Proveedores.Dto
{
    public class CreateProveedorDTO
{
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool Activo {get; set; } = false;
    public string Tipo {get; set; } = string.Empty;
}

}