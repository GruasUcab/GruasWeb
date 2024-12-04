namespace GrúasUCAB.Core.Proveedores.Entities
{
    public class Proveedor
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Tipo { get; private set; }
        public string Direccion { get; private set; }
        public string Email { get; private set; }
        public bool Activo { get; private set; }

        public Proveedor(Guid id, string nombre, string tipo, string direccion, string email, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Tipo = tipo;
            Direccion = direccion;
            Email = email;
            Activo = activo;
        }
    }
}
