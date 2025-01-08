using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Ordenes.Entities;
public class Proveedor
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; }
    public string Direccion { get; private set; }
    public string Telefono { get; private set; }
    public string Email { get; private set; }
    public bool Activo {get; private set; }
    public string Tipo {get; private set; }
    public ICollection<OrdenDeServicio> OrdenesDeServicio { get; private set; }
    // Relación con Vehículos
    

    public Proveedor(Guid id, string nombre, string direccion, string telefono, string email, bool activo, string tipo)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Email = email;
        Activo = activo;
        Tipo = tipo;
        OrdenesDeServicio = new List<OrdenDeServicio>();
    }

    // Constructor vacío para Entity Framework
   

    public void Update(string nombre, string direccion, string telefono, string email)
    {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Email = email;
    }
}
