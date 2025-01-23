using GrúasUCAB.Core.Ordenes.DTOs;
using MediatR;
using System;

namespace GrúasUCAB.Core.Ordenes.Queries{
public class GetOrdenDeServicioByIdQuery : IRequest<OrdenDeServicioDTO?>
{
    public Guid Id { get; set; }

    public GetOrdenDeServicioByIdQuery(Guid id)
    {
        Id = id;
    }
}

}