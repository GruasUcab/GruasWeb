using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Commands{

    public class DeleteAseguradoCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}

}