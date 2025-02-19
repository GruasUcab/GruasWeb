namespace GrúasUCAB.Core.Ordenes.DTOs{

    public class CreateVehiculoAseguradoDTO{
        public string Placa {get; set;}=string.Empty;
        public string Marca {get; set;}=string.Empty;
        public string Modelo {get; set;}= string.Empty;
        public string Tipo {get; set;}= string.Empty;
        public Guid AseguradoId {get; set;}
        public Guid PolizaId {get; set;}

    }
    public class UpdateVehiculoAseguradoDTO{

        public string Placa {get; set;}=string.Empty;
        public string Marca {get; set;}=string.Empty;
        public string Modelo {get; set;}= string.Empty;
        public string Tipo {get; set;}= string.Empty;        
        public Guid PolizaId {get; set;}

    }

    public class VehiculoAseguradoDTO{
        public Guid Id {get; set;}

        public string Placa {get; set;}=string.Empty;
        public string Marca {get; set;}=string.Empty;
        public string Modelo {get; set;}= string.Empty;
        public string Tipo {get; set;}= string.Empty;   
        public Guid AseguradoId {get; set;}     
        public Guid PolizaId {get; set;}

    }



    


}