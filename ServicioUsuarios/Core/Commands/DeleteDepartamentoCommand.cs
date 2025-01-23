using MediatR;

namespace GrúasUCAB.Core.Usuarios.Commands
{
    public class DeleteDepartamentoCommand : IRequest <Unit>
    {
        public Guid Id { get; set; }

        public DeleteDepartamentoCommand(Guid id)
        {
            Id = id;
        }
    }
}
