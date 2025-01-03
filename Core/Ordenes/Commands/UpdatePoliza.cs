using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{
    public class UpdatePolizaCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public UpdatePolizaDTO PolizaDTO { get; set; }

    public UpdatePolizaCommand(Guid id, UpdatePolizaDTO polizaDTO)
    {
        Id = id;
        PolizaDTO = polizaDTO;
    }
}

}