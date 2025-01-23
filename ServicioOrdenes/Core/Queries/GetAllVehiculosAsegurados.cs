using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;

namespace GrúasUCAB.Core.Ordenes.Queries{

    public class GetAllVehiculosAseguradosQuery : IRequest<IEnumerable<VehiculoAseguradoDTO>> { }
}