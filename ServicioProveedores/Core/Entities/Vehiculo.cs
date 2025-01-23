

namespace GrúasUCAB.Core.Proveedores.Entities{
public class Vehiculo
{
    public Guid Id { get; private set; }
    public string? Marca { get; private set; }
    public string? Modelo { get; private set; }
    public string? Placa { get; private set; }
    public Guid ProveedorId { get; private set; }
    public int Capacidad { get; private set; }
    public bool Activo { get; private set; }
 

    // Propiedad de navegación
    public Proveedor? Proveedor { get; private set; }

    // Constructor requerido por EF Core
    
    // Constructor utilizado en la aplicación
    public Vehiculo(Guid id, string marca, string modelo, string placa, Guid proveedorId, int capacidad, bool activo)
    {
        Id = id;
        Marca = marca;
        Modelo = modelo;
        Placa = placa;
        ProveedorId = proveedorId;
        Capacidad = capacidad;
        Activo = activo;
       
    }

    public void SetProveedor(Proveedor proveedor)
    {
        Proveedor = proveedor ?? throw new ArgumentNullException(nameof(proveedor));
    }

    public void Update(string modelo, string placa, int capacidad, bool activo, string marca)
        {
            Modelo = modelo;
            Placa = placa;
            Capacidad = capacidad;            
            Activo = activo;
            Marca = marca;
        }
}

}
