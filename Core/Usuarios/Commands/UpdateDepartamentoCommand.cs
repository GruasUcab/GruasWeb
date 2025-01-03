using GrúasUCAB.Core.Usuarios.Dto;
using MediatR;

namespace GrúasUCAB.Core.Usuarios.Commands
{
    public class UpdateDepartamentoCommand : IRequest <Unit>
    {
        public UpdateDepartamentoDto DepartamentoDto { get; set; }

        public UpdateDepartamentoCommand(UpdateDepartamentoDto departamentoDto)
        {
            DepartamentoDto = departamentoDto;
        }
    }
}
