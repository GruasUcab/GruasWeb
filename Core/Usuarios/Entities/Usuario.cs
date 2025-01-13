using System;

namespace GrúasUCAB.Core.Usuarios.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public string Apellido { get; private set; } = null!;
        public Guid DepartamentoId { get; private set; }
        public bool Activo { get; private set; }
        public string Sub { get; private set; } = null!; // Identificador de Keycloak
        public string Rol { get; private set; } = null!;

        public Usuario(Guid id, string nombre, string apellido, Guid departamentoId, bool activo, string sub, string rol)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DepartamentoId = departamentoId;
            Activo = activo;
            Sub = sub;
            Rol = rol;
        }
    }
}
