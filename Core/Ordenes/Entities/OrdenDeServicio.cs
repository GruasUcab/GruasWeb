using GrúasUCAB.Core.Proveedores.Entities;
using System;



namespace GrúasUCAB.Core.Ordenes.Entities
{
    public class OrdenDeServicio
    {
        public Guid Id { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public string? Estado { get; private set; } // Pendiente, Asignada, Completada, Cancelada
        public string? UbicacionIncidente { get; private set; }
        public string? UbicacionDestino { get; private set; }
        public decimal? KilometrosRecorridos { get; private set; }
        public decimal CostoTotal { get; private set; }
        public decimal CostoBase {get; private set;}
        public Guid AseguradoId {get; private set;}

        // Relaciones
        public Guid? ConductorId { get; private set; }       

        public Guid? ProveedorId { get; private set; }        

        public Guid? VehiculoId { get; private set; }       
        
        public OrdenDeServicio() {}

        public ICollection<CostoAdicional> CostosAdicionales { get; private set; } = new List<CostoAdicional>();
        

        public OrdenDeServicio(Guid id, DateTime fechaCreacion, string estado, string ubicacionIncidente, string ubicacionDestino, 
            decimal kilometrosRecorridos, decimal costoTotal,decimal costoBase, Guid? conductorId, Guid? proveedorId, Guid? vehiculoId, Guid aseguradoId)
        {
            Id = id;
            FechaCreacion = fechaCreacion;
            Estado = estado;
            UbicacionIncidente = ubicacionIncidente;
            UbicacionDestino = ubicacionDestino;
            KilometrosRecorridos = kilometrosRecorridos;
            CostoTotal = costoTotal;
            CostoBase = costoBase;
            ConductorId = conductorId;
            ProveedorId = proveedorId;
            VehiculoId = vehiculoId;
            AseguradoId = aseguradoId;
        }

         // Métodos para actualizar propiedades
        public void UpdateEstado(string nuevoEstado)
        {
            Estado = nuevoEstado;
        }

        public void UpdateKilometrosRecorridos(decimal nuevosKilometros)
        {
            KilometrosRecorridos = nuevosKilometros;
        }

        public void UpdateCostoTotal(decimal nuevoCostoTotal)
        {
            CostoTotal = nuevoCostoTotal;
        }

        public void UpdateCostoBase(decimal nuevoCostoBase)
        {
            CostoBase = nuevoCostoBase;
        }


        public void UpdateUbicaciones(string nuevaUbicacionIncidente, string nuevaUbicacionDestino)
        {
            UbicacionIncidente = nuevaUbicacionIncidente;
            UbicacionDestino = nuevaUbicacionDestino;
        }
    }
}


