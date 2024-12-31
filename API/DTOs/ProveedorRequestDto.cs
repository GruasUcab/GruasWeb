namespace GrúasUCAB.API.DTOs
{
    public class ProveedorRequestDto
    {
        public Guid Id {get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
