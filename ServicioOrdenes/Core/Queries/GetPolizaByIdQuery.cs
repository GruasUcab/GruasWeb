using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;
using System;

public class GetPolizaByIdQuery : IRequest<PolizaDTO>
{
    public Guid Id { get; set; }

    public GetPolizaByIdQuery(Guid id)
    {
        Id = id;
    }
}
