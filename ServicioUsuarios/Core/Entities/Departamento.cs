using System.Net;

namespace GrúasUCAB.Core.Usuarios.Entities
{
    public class Departamento
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Ubicacion { get; private set; }
        

        public Departamento(Guid id, string nombre, string ubicacion)
        {
            Id = id;
            Nombre = nombre;
            Ubicacion = ubicacion;
        }
        public void UpdateNombre(string nombre) => Nombre = nombre;
        public void UpdateDescripcion(string ubicacion) => Ubicacion = ubicacion;
    }
}
