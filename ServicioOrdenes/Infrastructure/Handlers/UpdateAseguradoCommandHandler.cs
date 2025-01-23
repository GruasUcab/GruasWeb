using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;


namespace GrúasUCAB.Infrastructure.Handlers.Ordenes{

public class UpdateAseguradoCommandHandler : IRequestHandler<UpdateAseguradoCommand, Unit>
{
    private readonly IAseguradoRepository _repository;

    public UpdateAseguradoCommandHandler(IAseguradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateAseguradoCommand request, CancellationToken cancellationToken)
    {
        var asegurado = await _repository.GetByIdAsync(request.Id);
        if (asegurado == null)
            throw new KeyNotFoundException("Asegurado no encontrado");

        asegurado.Update(request.AseguradoDto.Nombre, request.AseguradoDto.Apellido, request.AseguradoDto.DocumentoIdentidad, request.AseguradoDto.Telefono);
        await _repository.UpdateAsync(asegurado);
        await _repository.SaveChangesAsync();
        return Unit.Value;
    }
}

}