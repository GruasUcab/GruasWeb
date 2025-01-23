using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Queries{
public class GetAllPolizasQuery : IRequest<IEnumerable<PolizaDTO>>
{
}

}