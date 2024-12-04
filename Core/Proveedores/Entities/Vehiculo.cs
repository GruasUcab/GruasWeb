namespace GrúasUCAB.Core.Proveedores.Entities
{
    public class Vehiculo
    {
        public Guid Id { get; private set; }
        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public int Capacidad { get; private set; }
        public bool Activo { get; private set; }

        // Relación con Proveedor
        public Guid ProveedorId { get; private set; }
        public Proveedor Proveedor { get; private set; }

        public Vehiculo(Guid id, string placa, string modelo, int capacidad, bool activo, Guid proveedorId)
        {
            Id = id;
            Placa = placa;
            Modelo = modelo;
            Capacidad = capacidad;
            Activo = activo;
            ProveedorId = proveedorId;
        }
    }
}
