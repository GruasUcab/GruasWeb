using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{
public class CreatePolizaCommand : IRequest<Guid>
{
    public CreatePolizaDTO PolizaDTO { get; set; }

    public CreatePolizaCommand(CreatePolizaDTO polizaDTO)
    {
        PolizaDTO = polizaDTO;
    }
}


}