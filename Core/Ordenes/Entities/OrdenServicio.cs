using System;

namespace GrúasUCAB.Core.Ordenes.Entities
{
    public class OrdenServicio
    {
        public Guid Id { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public string Estado { get; private set; }
        public string UbicacionIncidente { get; private set; }
        public string UbicacionDestino { get; private set; }
        public decimal KilometrosRecorridos { get; private set; }
        public decimal CostoTotal { get; private set; }

        // Relaciones
        public Guid IdConductor { get; private set; }
        public Guid IdProveedor { get; private set; }
        public Guid IdVehiculo { get; private set; }

        public OrdenServicio(Guid id, DateTime fechaCreacion, string estado, string ubicacionIncidente, string ubicacionDestino,
                              decimal kilometrosRecorridos, decimal costoTotal, Guid idConductor, Guid idProveedor, Guid idVehiculo)
        {
            Id = id;
            FechaCreacion = fechaCreacion;
            Estado = estado;
            UbicacionIncidente = ubicacionIncidente;
            UbicacionDestino = ubicacionDestino;
            KilometrosRecorridos = kilometrosRecorridos;
            CostoTotal = costoTotal;
            IdConductor = idConductor;
            IdProveedor = idProveedor;
            IdVehiculo = idVehiculo;
        }
    }
}
