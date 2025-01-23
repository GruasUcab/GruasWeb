namespace GrúasUCAB.Core.Ordenes.DTOs{

    public class CreateAseguradoDTO
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string DocumentoIdentidad { get; set; }
        public required string Telefono { get; set; }
        
    }


    public class UpdateAseguradoDTO
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string DocumentoIdentidad { get; set; }
        public required string Telefono { get; set; }
    }



    public class AseguradoDTO
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string DocumentoIdentidad { get; set; }
        public required string Telefono { get; set; }
        
    }

    




}


