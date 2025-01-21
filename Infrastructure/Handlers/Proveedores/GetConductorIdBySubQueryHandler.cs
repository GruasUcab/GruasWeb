using GrúasUCAB.Core.Proveedores.Repositories;
using MediatR;
using GrúasUCAB.Core.Proveedores.Queries;

namespace GrúasUCAB.Infrastructure.Handlers{

    public class GetConductorIdBySubQueryHandler : IRequestHandler<GetConductorIdBySubQuery, Guid?>
{
    private readonly IConductorRepository _repository;

    public GetConductorIdBySubQueryHandler(IConductorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid?> Handle(GetConductorIdBySubQuery request, CancellationToken cancellationToken)
    {
        var conductor = await _repository.GetBySubAsync(request.Sub);
        return conductor?.Id;
    }
}

}