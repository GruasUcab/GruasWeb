using GrúasUCAB.Core.Usuarios.DTOs;
using MediatR;

namespace GrúasUCAB.Core.Usuarios.Commands
{
   public class UpdateUsuarioCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public Guid DepartamentoId { get; set; }
    public bool Activo { get; set; }
    public string Password { get; set; } = null!;
}




}
