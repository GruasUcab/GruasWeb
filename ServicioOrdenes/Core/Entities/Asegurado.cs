namespace GrúasUCAB.Core.Ordenes.Entities
{
    public class Asegurado
    {
        public Guid Id { get; private set; }
        public string? Nombre { get; private set; }
        public string? Apellido { get; private set; }
        public string? DocumentoIdentidad { get; private set; }
        public string? Telefono { get; private set; }        

        public Asegurado() {}
        public ICollection<VehiculoAsegurado> CostosAdicionales { get; private set; } = new List<VehiculoAsegurado>();
        

        public Asegurado(Guid id, string nombre, string apellido, string documentoIdentidad, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DocumentoIdentidad = documentoIdentidad;
            Telefono = telefono;
            
        }

        public void Update(string nombre, string apellido, string documentoIdentidad, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            DocumentoIdentidad = documentoIdentidad;
            Telefono = telefono;
        }
    }
}
