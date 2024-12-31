namespace GrúasUCAB.Core.Usuarios.DTOs
{
    public class CreateUsuarioDTO
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public required string Clave { get; set; }
        public bool Activo { get; set; }
        public required string TipoUsuario { get; set; }
        public Guid DepartamentoId { get; set; }
    }
}
