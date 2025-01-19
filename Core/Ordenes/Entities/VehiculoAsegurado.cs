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
    public Guid PolizaId {get; private set;}

    public Asegurado Asegurado {get; private set;} = null!;

    public VehiculoAsegurado(Guid id, string placa, string marca, string modelo, string tipo, Guid aseguradoId, Guid polizaId){
        
        Id = id;
        Placa = placa;
        Marca = marca;
        Modelo = modelo;
        Tipo = tipo;
        AseguradoId = aseguradoId;
        PolizaId = polizaId;
    }
    
    public void Update(string placa, string marca, string modelo, string tipo, Guid polizaId)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Tipo = tipo;
            PolizaId = polizaId;
        }

}
}