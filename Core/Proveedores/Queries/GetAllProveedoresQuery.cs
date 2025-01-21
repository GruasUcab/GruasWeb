using GrúasUCAB.Core.Proveedores.Dto;
using MediatR;
using System.Collections.Generic;

namespace GrúasUCAB.Core.Proveedores.Queries
{
    public class GetAllProveedoresQuery : IRequest<IEnumerable<ProveedorDTO>>
    {
    }
}

