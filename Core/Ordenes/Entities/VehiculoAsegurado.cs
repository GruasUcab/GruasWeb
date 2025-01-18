using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Queries;

namespace GrúasUCAB.Core.Ordenes.Entities{

public class VehiculoAsegurado {

    public Guid Id {get; private set;}
    public  string? Placa {get; private set;}
    public string? Marca {get; private set;}
    public string? Modelo {get; private set; }
    public string? Tipo {get; private set; }
    public Guid AseguradoId {get; private set;}

    public Asegurado Asegurado {get; private set;} = null!;

    public VehiculoAsegurado(Guid id, string placa, string modelo, string tipo, Guid aseguradoId){
        
        Id = id;
        Placa = placa;
        Modelo = modelo;
        Tipo = tipo;
        AseguradoId = aseguradoId;
    }
    


}
}