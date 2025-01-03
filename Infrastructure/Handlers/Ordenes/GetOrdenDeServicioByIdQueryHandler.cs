using AutoMapper;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Repositories;
using MediatR;
using GrúasUCAB.Core.Ordenes.Queries;
using System.Threading;
using System.Threading.Tasks;

public class GetOrdenDeServicioByIdQueryHandler : IRequestHandler<GetOrdenDeServicioByIdQuery, OrdenDeServicioDTO?>
{
    private readonly IOrdenDeServicioRepository _repository;
    private readonly IMapper _mapper;

    public GetOrdenDeServicioByIdQueryHandler(IOrdenDeServicioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<OrdenDeServicioDTO?> Handle(GetOrdenDeServicioByIdQuery request, CancellationToken cancellationToken)
    {
        var orden = await _repository.GetByIdAsync(request.Id);
        return orden == null ? null : _mapper.Map<OrdenDeServicioDTO>(orden);
    }
}
