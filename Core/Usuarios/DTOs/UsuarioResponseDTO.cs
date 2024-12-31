public class UsuarioResponseDTO
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Email { get; set; }
    public bool Activo { get; set; }
    public required string TipoUsuario { get; set; }
}
