using GrúasUCAB.Core.Usuarios.Dto;
using MediatR;

namespace GrúasUCAB.Core.Usuarios.Commands
{
    public class CreateDepartamentoCommand : IRequest<Guid>
    {
        public CreateDepartamentoDto DepartamentoDto { get; set; }

        public CreateDepartamentoCommand(CreateDepartamentoDto departamentoDto)
        {
            DepartamentoDto = departamentoDto;
        }
    }
}
