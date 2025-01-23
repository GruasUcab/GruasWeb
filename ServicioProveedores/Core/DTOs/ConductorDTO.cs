namespace GrúasUCAB.Core.Proveedores.Dto{
public class CreateConductorDTO
{
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Licencia { get; set; }
    public required string Telefono {get; set; }
    public required bool Activo {get; set;}
    public Guid ProveedorId { get; set; }
    public  required string DocumentoIdentidad {get; set;}
    public string Password {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string Username {get; set;} = string.Empty;
    
}

public class UpdateConductorDTO
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Licencia { get; set; }
    public Guid ProveedorId { get; set; }
}

public class UpdateConductorUbicacionDTO
{    
    public required string Latitud { get; set; }
    public required string Longitud { get; set; }
    
}


public class ConductorDTO
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Licencia { get; set; }
    public required string Sub {get; set;}
    public bool Activo {get; set;}
    public Guid ProveedorId { get; set; }
    public required string Latitud { get; set; }
    public required string Longitud { get; set; }
}


}