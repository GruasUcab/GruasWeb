using MediatR;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Core.Usuarios.Queries;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios{

    public class GetUsuarioIdBySubQueryHandler : IRequestHandler<GetUsuarioIdBySubQuery, Guid?>
{
    private readonly IUsuarioRepository _repository;

    public GetUsuarioIdBySubQueryHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid?> Handle(GetUsuarioIdBySubQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _repository.GetBySubAsync(request.Sub);
        return usuario?.Id;
    }
}

}