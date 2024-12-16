namespace GrúasUCAB.API.DTOs
{
    public class VehiculoResponseDto
    {
        public Guid Id { get; set; }
        public string Placa { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int Capacidad { get; set; }
        public bool Activo { get; set; }
        public Guid ProveedorId { get; set; }
    }
}
