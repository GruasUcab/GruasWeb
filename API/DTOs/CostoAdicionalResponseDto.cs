namespace GrúasUCAB.API.DTOs
{
    public class CostoAdicionalResponseDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Monto { get; set; }
        public Guid OrdenId { get; set; }
    }
}
