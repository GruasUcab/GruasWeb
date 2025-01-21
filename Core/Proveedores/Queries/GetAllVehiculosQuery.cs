using GrúasUCAB.Core.Proveedores.Dto;
using GrúasUCAB.Core.Proveedores.DTO;
using MediatR;
using System.Collections.Generic;

namespace GrúasUCAB.Core.Proveedores.Queries
{
    public class GetAllVehiculosQuery : IRequest<IEnumerable<VehiculoDTO>>
    {
    }
}