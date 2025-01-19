using MediatR;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Queries;
using GrúasUCAB.Core.Ordenes.Repositories;

namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

    public class GetAllAseguradosQueryHandler : IRequestHandler<GetAllAseguradosQuery, IEnumerable<AseguradoDTO>>
{
    private readonly IAseguradoRepository _repository;

    public GetAllAseguradosQueryHandler(IAseguradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AseguradoDTO>> Handle(GetAllAseguradosQuery request, CancellationToken cancellationToken)
    {
        var asegurados = await _repository.GetAllAsync();
        return asegurados.Select(a => new AseguradoDTO
        {
            Id = a.Id,
            Nombre = a.Nombre?? string.Empty,
            Apellido = a.Apellido?? string.Empty,
            DocumentoIdentidad = a.DocumentoIdentidad?? string.Empty,
            Telefono = a.Telefono?? string.Empty
        });
    }
}
}