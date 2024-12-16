namespace GrúasUCAB.API.DTOs
{
    public class DepartamentoResponseDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
