using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Queries;
using GrúasUCAB.Core.Ordenes.Repositories;

namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

    public class GetCostoAdicionalByIdQueryHandler : IRequestHandler<GetCostoAdicionalByIdQuery, CostoAdicionalDTO>
{
    private readonly ICostoAdicionalRepository _repository;

    public GetCostoAdicionalByIdQueryHandler(ICostoAdicionalRepository repository)
    {
        _repository = repository;
    }

    public async Task<CostoAdicionalDTO> Handle(GetCostoAdicionalByIdQuery request, CancellationToken cancellationToken)
    {
        var costoAdicional = await _repository.GetByIdAsync(request.Id);

        if (costoAdicional == null)
        {
            throw new KeyNotFoundException("El costo adicional no existe.");
        }

        return new CostoAdicionalDTO
        {
            Id = costoAdicional.Id,
            Nombre = costoAdicional.Nombre,
            Descripcion = costoAdicional.Descripcion,
            Monto = costoAdicional.Monto,
            OrdenId = costoAdicional.OrdenId

        };
    }
}

}