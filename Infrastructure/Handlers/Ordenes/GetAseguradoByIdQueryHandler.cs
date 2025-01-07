using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Queries;
using GrúasUCAB.Core.Ordenes.Repositories;

namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

    public class GetAseguradoByIdQueryHandler : IRequestHandler<GetAseguradoByIdQuery, AseguradoDTO>
{
    private readonly IAseguradoRepository _repository;

    public GetAseguradoByIdQueryHandler(IAseguradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<AseguradoDTO> Handle(GetAseguradoByIdQuery request, CancellationToken cancellationToken)
    {
        var asegurado = await _repository.GetByIdAsync(request.Id);
        if (asegurado == null)
            throw new KeyNotFoundException("Asegurado no encontrado");

        return new AseguradoDTO
        {
            Id = asegurado.Id,
            Nombre = asegurado.Nombre,
            Apellido = asegurado.Apellido,
            DocumentoIdentidad = asegurado.DocumentoIdentidad,
            Telefono = asegurado.Telefono
        };
    }
}
};
