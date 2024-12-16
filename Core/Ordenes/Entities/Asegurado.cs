namespace GrúasUCAB.Core.Ordenes.Entities
{
    public class Asegurado
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Telefono { get; private set; }
        public string Email { get; private set; }

        // Relación con Poliza
        public Guid PolizaId { get; private set; }
        public Poliza Poliza { get; private set; } = null!;

        public Asegurado(Guid id, string nombre, string telefono, string email, Guid polizaId)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            PolizaId = polizaId;
        }
    }
}
