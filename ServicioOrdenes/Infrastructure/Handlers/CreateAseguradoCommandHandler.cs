using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

public class CreateAseguradoCommandHandler : IRequestHandler<CreateAseguradoCommand, Guid>
{
    private readonly IAseguradoRepository _repository;

    public CreateAseguradoCommandHandler(IAseguradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateAseguradoCommand request, CancellationToken cancellationToken)
    {
        var asegurado = new Asegurado(Guid.NewGuid(), request.AseguradoDto.Nombre, request.AseguradoDto.Apellido, request.AseguradoDto.DocumentoIdentidad, request.AseguradoDto.Telefono);
        await _repository.AddAsync(asegurado);
        await _repository.SaveChangesAsync();
        return asegurado.Id;
    }
}

}