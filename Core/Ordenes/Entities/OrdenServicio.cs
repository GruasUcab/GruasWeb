using GrúasUCAB.Core.Proveedores.Entities;

namespace GrúasUCAB.Core.Ordenes.Entities
{
    public class OrdenServicio
    {
        public Guid Id { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public string Estado { get; private set; }
        public string UbicacionIncidente { get; private set; }
        public string UbicacionDestino { get; private set; }
        public int KilometrosRecorridos { get; private set; }
        public decimal CostoTotal { get; private set; }

        // Relación con Conductor
        public Guid? ConductorId { get; private set; }
        public Conductor? Conductor { get; private set; }

        // Relación con Proveedor
        public Guid? ProveedorId { get; private set; }
        public Proveedor? Proveedor { get; private set; }

        // Relación con Vehículo
        public Guid? VehiculoId { get; private set; }
        public Vehiculo? Vehiculo { get; private set; }

        // Relación con Costo Adicional
        public ICollection<CostoAdicional> CostosAdicionales { get; private set; } = new List<CostoAdicional>();

        public OrdenServicio(Guid id, DateTime fechaCreacion, string estado, string ubicacionIncidente,
            string ubicacionDestino, int kilometrosRecorridos, decimal costoTotal, Guid? conductorId,
            Guid? proveedorId, Guid? vehiculoId)
        {
            Id = id;
            FechaCreacion = fechaCreacion;
            Estado = estado;
            UbicacionIncidente = ubicacionIncidente;
            UbicacionDestino = ubicacionDestino;
            KilometrosRecorridos = kilometrosRecorridos;
            CostoTotal = costoTotal;
            ConductorId = conductorId;
            ProveedorId = proveedorId;
            VehiculoId = vehiculoId;
        }
    }
}
