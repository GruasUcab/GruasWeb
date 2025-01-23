using MediatR;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Core.Usuarios.Queries;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios{

    public class GetProveedorIdBySubQueryHandler : IRequestHandler<GetProveedorIdBySubQuery, Guid?>
{
    private readonly IUsuarioRepository _repository;

    public GetProveedorIdBySubQueryHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid?> Handle(GetProveedorIdBySubQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _repository.GetBySubAsync(request.Sub);
        return usuario?.ProveeId;
    }
}

}