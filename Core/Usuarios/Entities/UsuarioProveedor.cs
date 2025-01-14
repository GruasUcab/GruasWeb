using System;

namespace GrúasUCAB.Core.Usuarios.Entities
{
    public class UsuarioProveedor
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public string Apellido { get; private set; } = null!;        
        public bool Activo { get; private set; }
        public string Sub { get; private set; } = null!; // Identificador de Keycloak
        public string Rol { get; private set; } = null!;
        public Guid ProveedorId {get; private set;}
        

        public UsuarioProveedor(Guid id, string nombre, string apellido, bool activo, string sub, string rol, Guid proveedorId)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;            
            Activo = activo;
            Sub = sub;
            Rol = rol;
            ProveedorId = proveedorId;
            
        }

        
        
    }
}
