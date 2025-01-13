namespace GrúasUCAB.Core.Usuarios.DTOs
{
    public class CreateUsuarioDTO
{
    
    public string Nombre { get; set; } = string.Empty;
   
    public string Apellido { get; set; } = string.Empty;    
    public Guid DepartamentoId { get; set; }
    public bool Activo { get; set; }    
    public string Password { get; set; } = string.Empty;   
    public string Email { get; set; } = string.Empty;    
    public string Username { get; set; } = string.Empty;
}


    public class UpdateUsuarioDTO
{
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public Guid DepartamentoId { get; set; }
    public bool Activo { get; set; }
    public List<string> Roles { get; set; } = new();
}


}
