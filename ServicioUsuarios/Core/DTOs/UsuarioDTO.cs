namespace GrúasUCAB.Core.Usuarios.Dto
{
    public class CreateUsuarioDTO
{
    
    public string Nombre { get; set; } = string.Empty;   
    public string Apellido { get; set; } = string.Empty;    
    public Guid? DepartamentoId { get; set; }
    public bool Activo { get; set; }    
    public string Password { get; set; } = string.Empty;   
    public string Email { get; set; } = string.Empty;    
    public string Username { get; set; } = string.Empty;    
    
    
}

public class CreateUsuarioProveedorDTO
{
    
    public string Nombre { get; set; } = string.Empty;   
    public string Apellido { get; set; } = string.Empty;        
    public bool Activo { get; set; }    
    public string Password { get; set; } = string.Empty;   
    public string Email { get; set; } = string.Empty;    
    public string Username { get; set; } = string.Empty;   
    public Guid? ProveeId {get; set; }
    
    
}


    public class UpdateUsuarioDTO
{
    public Guid Id {get; set;}
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public Guid DepartamentoId { get; set; }
    public bool Activo { get; set; }    
}


public class UpdateUsuarioProveedorDTO
{
    public Guid Id {get; set;}
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public Guid ProveedorId { get; set; }
    public bool Activo { get; set; }    
}


public class UsuarioDTO
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public Guid? DepartamentoId { get; set; }
    public bool Activo { get; set; }
    public string Sub { get; set; } = null!;
    public Guid? ProveeId { get; set; }
}

}
