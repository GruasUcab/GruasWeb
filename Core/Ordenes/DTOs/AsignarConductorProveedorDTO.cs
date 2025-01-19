namespace GrúasUCAB.Core.Ordenes.DTOs{
    public class AsignarConductorProveedorDTO
{
    public Guid OrdenId { get; set; }
    public Guid ConductorId { get; set; }
    public Guid ProveedorId { get; set; }
    public required string UbicacionConductor { get; set; }
}




}