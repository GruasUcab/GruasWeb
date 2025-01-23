
using MediatR;
using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;
using GrúasUCAB.Core.Usuarios.Queries;


namespace GrúasUCAB.Infrastructure.Handlers.Usuarios{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, Usuario?>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public GetUsuarioByIdQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario?> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
    {
        return await _usuarioRepository.GetByIdAsync(request.Id);
    }
}
    
}