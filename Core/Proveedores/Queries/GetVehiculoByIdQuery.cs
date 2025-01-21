using GrúasUCAB.Core.Proveedores.Dto;
using MediatR;
using System.Collections.Generic;

namespace GrúasUCAB.Core.Proveedores.Queries{

public class GetVehiculoByIdQuery : IRequest<GetVehiculoDTO>
{
    public Guid Id { get; set; }

    public GetVehiculoByIdQuery(Guid id)
    {
        Id = id;
    }
}
}