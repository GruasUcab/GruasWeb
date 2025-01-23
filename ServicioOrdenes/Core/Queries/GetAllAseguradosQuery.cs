using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Queries{

    public class GetAllAseguradosQuery : IRequest<IEnumerable<AseguradoDTO>> { }
}