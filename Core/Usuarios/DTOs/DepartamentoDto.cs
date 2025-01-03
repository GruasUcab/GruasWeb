namespace GrúasUCAB.Core.Usuarios.Dto
{
    public class DepartamentoDto
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
    }

    public class CreateDepartamentoDto
    {
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
    }

    public class UpdateDepartamentoDto
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
    }
}
