using MediatR;


namespace GrúasUCAB.Core.Usuarios.Commands
{
    public class DeleteUsuarioCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}





}
