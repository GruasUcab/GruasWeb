using System;

namespace GrúasUCAB.Core.Usuarios.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public string Apellido { get; private set; } = null!;
        public Guid? DepartamentoId { get; private set; }
        public bool Activo { get; private set; }
        public string Sub { get; private set; } = null!; // Identificador de Keycloak        
        public Guid? ProveeId {get; private set; }        
        

        public Usuario(Guid id, string nombre, string apellido, Guid? departamentoId, bool activo, string sub, string rol)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DepartamentoId = departamentoId;
            Activo = activo;
            Sub = sub;            
            
            
        }

        public Usuario(Guid id, string nombre, string apellido, Guid? departamentoId, bool activo, string sub, Guid? proveeId)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DepartamentoId = departamentoId;
            Activo = activo;
            Sub = sub;
            ProveeId = proveeId;

            
            
        }

        public void UpdateNombre(string nombre) => Nombre = nombre;
        public void UpdateApellido(string apellido) => Apellido = apellido;
        public void UpdateDepartamento(Guid departamentoId) => DepartamentoId = departamentoId;
        public void UpdateActivo(bool activo) => Activo = activo;        
        public void UpdateProveedor(Guid proveeId) => ProveeId = proveeId;
        
    }
}
