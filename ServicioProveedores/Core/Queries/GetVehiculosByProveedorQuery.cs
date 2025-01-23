using GrúasUCAB.Core.Proveedores.Dto;
using GrúasUCAB.Core.Proveedores.DTO;
using MediatR;
using System.Collections.Generic;

namespace GrúasUCAB.Core.Proveedores.Queries
{
    public record GetVehiculosByProveedorQuery(Guid ProveedorId) : IRequest<IEnumerable<CreateVehiculoDTO>>;    

}
