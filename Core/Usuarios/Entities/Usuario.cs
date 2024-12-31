namespace GrúasUCAB.Core.Usuarios.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public string Clave { get; private set; }
        public bool Activo { get; private set; }
        public string TipoUsuario { get; private set; }
        public Guid DepartamentoId { get; private set; }
        

        public Usuario(Guid id, string nombre, string apellido, string email, string clave, bool activo, string tipoUsuario, Guid departamentoId)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Clave = clave;
            Activo = activo;
            TipoUsuario = tipoUsuario;
            DepartamentoId = departamentoId;
        }
    
    public void UpdateNombre(string nombre) => Nombre = nombre;
    public void UpdateApellido(string apellido) => Apellido = apellido;
    public void UpdateEmail(string email) => Email = email;
    public void UpdateClave(string clave) => Clave = clave;
    public void UpdateActivo(bool activo) => Activo = activo;
    public void UpdateTipoUsuario(string tipoUsuario) => TipoUsuario = tipoUsuario;
    public void UpdateDepartamento(Guid departamentoId) => DepartamentoId = departamentoId;
    }
}
