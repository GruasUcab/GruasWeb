using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class CreateOrdenDeServicioCommandHandler : IRequestHandler<CreateOrdenDeServicioCommand, Guid>
{
    private readonly IOrdenDeServicioRepository _repository;

    public CreateOrdenDeServicioCommandHandler(IOrdenDeServicioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateOrdenDeServicioCommand request, CancellationToken cancellationToken)
    {
        var dto = request.OrdenDeServicioDTO;

        

        var orden = new OrdenDeServicio(
            Guid.NewGuid(),              
            dto.UbicacionIncidente,
            dto.UbicacionDestino,            
            dto.CostoBase,
            dto.AseguradoId
            
        );

        await _repository.AddAsync(orden);
        return orden.Id;
    }
}
