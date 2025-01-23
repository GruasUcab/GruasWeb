

namespace GrúasUCAB.Core.Proveedores.Entities
{
    public class Conductor
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public string Licencia { get; private set; }
    public string? Latitud {get; private set;}
    public string? Longitud {get; private set;}
    public string Telefono {get; private set; }
    public bool Activo {get; set; }
    public Guid ProveedorId { get; private set; }
    public string DocumentoIdentidad {get; private set; }
    public string Sub { get; private set; } = null!; // Identificador de Keycloak
    
        

    

    public Conductor(Guid id, string nombre, string apellido, string licencia, string telefono, bool activo, Guid proveedorId, string documentoIdentidad, string sub)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Licencia = licencia;
        Telefono = telefono;
        Activo = activo;
        ProveedorId = proveedorId;
        DocumentoIdentidad = documentoIdentidad;
        Sub = sub;        

        
    }

    public void Update(string nombre, string apellido, string licencia, Guid proveedorId)
    {
        Nombre = nombre;
        Apellido = apellido;
        Licencia = licencia;
        ProveedorId = proveedorId;
    }

    public void UpdateUbicacion(string latitud, string longitud)
    {
        Latitud = latitud;
        Longitud = longitud;


    }

    public void CambiarEstado(bool activo){        
        Activo = activo;
    }
}

}
