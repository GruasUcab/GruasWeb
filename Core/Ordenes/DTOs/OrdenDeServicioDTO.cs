using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Ordenes.DTOs{

public class CreateOrdenDeServicioDTO
{
    
    public required string UbicacionIncidente { get; set; }
    public required string UbicacionDestino { get; set; }     
    public Guid AseguradoId { get; set; }  
    public Guid VehiculoAseguradoId {get; set;} 
    public decimal KilometrosRecorridos {get; set;} 
    public required string LatitudIncidente {get; set; } 
    public required string LongitudIncidente {get; set;}
    public required string LatitudDestino {get; set;}
    public required string LongitudDestino {get; set;}
}




public class UpdateOrdenDeServicioDTO
{
    public Guid Id { get; set; }    
    public decimal KilometrosRecorridos { get; set; }
    public decimal CostoTotal { get; set; }
    public decimal CostoBase {get; set; }
}


public class OrdenDeServicioDTO
{
    public Guid Id { get; set; }
    public DateTime FechaCreacion { get; set; }
    public required EstadoOrden Estado { get; set; }
    public required string UbicacionIncidente { get; set; }
    public required string UbicacionDestino { get; set; }
    public decimal KilometrosRecorridos { get; set; }
    public decimal CostoTotal { get; set; }
    public decimal CostoBase {get; set;}
    public Guid? ConductorId { get; set; }
    public Guid? ProveedorId { get; set; }
    public Guid? VehiculoId { get; set; }
    
}



}