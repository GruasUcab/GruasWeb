using GrúasUCAB.Core.Proveedores.Entities;

public class Proveedor
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; }
    public string Direccion { get; private set; }
    public string Telefono { get; private set; }
    public string Email { get; private set; }
    public bool Activo {get; private set; }
    public string Tipo {get; private set; }
    

    // Relación con Vehículos
    public ICollection<Vehiculo> Vehiculos { get; private set; } = new List<Vehiculo>();

    public Proveedor(Guid id, string nombre, string direccion, string telefono, string email, bool activo, string tipo)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Email = email;
        Activo = activo;
        Tipo = tipo;  
        

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
