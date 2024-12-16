namespace GrúasUCAB.API.DTOs
{
    public class CostoAdicionalRequestDto
    {
        public string Nombre { get; set; } = null!;
        public decimal Monto { get; set; }
        public Guid OrdenId { get; set; }
    }
}
