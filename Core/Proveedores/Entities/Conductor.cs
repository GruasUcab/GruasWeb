using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Proveedores.Entities
{
    public class Conductor
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Telefono { get; private set; }
        public string Licencia { get; private set; }
        public bool Activo { get; private set; }

        // Relación con OrdenServicio
        public ICollection<OrdenServicio> Ordenes { get; private set; } = new List<OrdenServicio>();

        public Conductor(Guid id, string nombre, string telefono, string licencia, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
            Licencia = licencia;
            Activo = activo;
        }
    }
}
