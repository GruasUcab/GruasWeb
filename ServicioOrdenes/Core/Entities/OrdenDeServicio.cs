using System;
using System.Collections.Specialized;
using System.ComponentModel;



namespace GrúasUCAB.Core.Ordenes.Entities
{
    public enum EstadoOrden
    {
        Pendiente,        
        Asignada,  
        Localizada,      
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
        public string? LatitudIncidente {get; private set; }
        public string? LongitudIncidente {get; private set;}
        public string? LatitudDestino {get; private set;}
        public string? LongitudDestino {get; private set;}

        public string? LatitudConductor { get; private set; }
    
        public string? LongitudConductor { get; private set; }


        public decimal CostoTotal { get;  set; }
        public decimal? CostoBase {get;  set;}
        public Guid AseguradoId {get; private set;}
        public Guid VehiculoAseguradoId {get; private set;}

        // Relaciones
        public Guid? ConductorId { get; private set; }       

        public Guid? ProveedorId { get; private set; }        

        public Guid? VehiculoId { get; private set; }             
        
        public OrdenDeServicio() {}

        public ICollection<CostoAdicional> CostosAdicionales { get; private set; } = new List<CostoAdicional>();

        public void CambiarEstado(EstadoOrden nuevoEstado)
    {
        Estado = nuevoEstado;
    }
        
        

        public OrdenDeServicio(Guid id, string ubicacionIncidente, string ubicacionDestino, Guid aseguradoId, Guid vehiculoAseguradoId, decimal kilometrosRecorridos, string latitudDestino, string longitudDestino, string latitudIncidente, string longitudIncidente)
        {
            Id = id;            
            UbicacionIncidente = ubicacionIncidente;
            UbicacionDestino = ubicacionDestino;            
            AseguradoId = aseguradoId;
            VehiculoAseguradoId = vehiculoAseguradoId;
            KilometrosRecorridos = kilometrosRecorridos;
            LatitudDestino = latitudDestino;
            LongitudDestino = longitudDestino;
            LatitudIncidente = latitudIncidente;
            LongitudIncidente = longitudIncidente;
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

        public void AsignarConductorYProveedor(Guid conductorId, Guid proveedorId, string latitud, string longitud)
    {
        ConductorId = conductorId;
        ProveedorId = proveedorId;
        LatitudConductor = latitud;
        LongitudConductor = longitud;

    }
    }
}


