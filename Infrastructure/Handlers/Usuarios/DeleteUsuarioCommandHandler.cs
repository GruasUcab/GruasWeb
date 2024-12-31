using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Repositories;
using MediatR;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, Unit>
{
    private readonly IUsuarioRepository _repository;

    public DeleteUsuarioCommandHandler(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _repository.GetByIdAsync(request.Id);

        if (usuario == null)
            throw new KeyNotFoundException($"Usuario with Id {request.Id} not found.");

        await _repository.DeleteAsync(request.Id);       
        return Unit.Value;
    }
}

}
