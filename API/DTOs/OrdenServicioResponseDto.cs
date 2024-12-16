namespace GrúasUCAB.API.DTOs
{
    public class OrdenServicioResponseDto
    {
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; } = null!;
        public string UbicacionIncidente { get; set; } = null!;
        public string UbicacionDestino { get; set; } = null!;
        public int KilometrosRecorridos { get; set; }
        public decimal CostoTotal { get; set; }
        public Guid? ConductorId { get; set; }
        public Guid? ProveedorId { get; set; }
        public Guid? VehiculoId { get; set; }
    }
}
