using GrúasUCAB.Core.Proveedores.Entities;
using System;
using System.Collections.Specialized;



namespace GrúasUCAB.Core.Ordenes.Entities
{
    public enum EstadoOrden
    {
        Pendiente,
        Asignada,
        Completada,
        Cancelada
    }
    public class OrdenDeServicio
    {
        public Guid Id { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public EstadoOrden Estado { get; private set; } // Pendiente, Asignada, Completada, Cancelada
        public string? UbicacionIncidente { get; private set; }
        public string? UbicacionDestino { get; private set; }
        public decimal? KilometrosRecorridos { get; private set; }
        public decimal CostoTotal { get; private set; }
        public decimal? CostoBase {get; private set;}
        public Guid AseguradoId {get; private set;}

        // Relaciones
        public Guid? ConductorId { get; private set; }       

        public Guid? ProveedorId { get; private set; }        

        public Guid? VehiculoId { get; private set; }
        public string? UbicacionConductor {get; private set;}       
        
        public OrdenDeServicio() {}

        public ICollection<CostoAdicional> CostosAdicionales { get; private set; } = new List<CostoAdicional>();

        public void CambiarEstado(EstadoOrden nuevoEstado)
    {
        Estado = nuevoEstado;
    }
        
        

        public OrdenDeServicio(Guid id, string ubicacionIncidente, string ubicacionDestino,decimal costoBase, Guid aseguradoId)
        {
            Id = id;            
            UbicacionIncidente = ubicacionIncidente;
            UbicacionDestino = ubicacionDestino;         
            CostoBase = costoBase;      
            AseguradoId = aseguradoId;
        }

         // Métodos para actualizar propiedades
        

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

        public void AsignarConductorYProveedor(Guid conductorId, Guid proveedorId, string ubicacionConductor)
    {
        ConductorId = conductorId;
        ProveedorId = proveedorId;
        UbicacionConductor = ubicacionConductor;
    }
    }
}


