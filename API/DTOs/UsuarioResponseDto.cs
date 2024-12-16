namespace GrúasUCAB.API.DTOs
{
    public class UsuarioResponseDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }
        public string TipoUsuario { get; set; } = null!;
        public Guid DepartamentoId { get; set; }
    }
}
