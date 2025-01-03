namespace GrúasUCAB.Core.Usuarios.Entities
{
    public class Departamento
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }

        public Departamento(Guid id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
        public void UpdateNombre(string nombre) => Nombre = nombre;
        public void UpdateDescripcion(string descripcion) => Descripcion = descripcion;
    }
}
