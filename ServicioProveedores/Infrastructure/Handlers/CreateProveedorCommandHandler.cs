using MediatR;
using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Commands;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
    public class CreateProveedorCommandHandler : IRequestHandler<CreateProveedorCommand, Guid>
{
    private readonly IProveedorRepository _repository;

    public CreateProveedorCommandHandler(IProveedorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateProveedorCommand request, CancellationToken cancellationToken)
    {
        var proveedor = new Proveedor(
            Guid.NewGuid(),
            request.ProveedorDto.Nombre,
            request.ProveedorDto.Direccion,
            request.ProveedorDto.Telefono,
            request.ProveedorDto.Email,
            request.ProveedorDto.Activo,
            request.ProveedorDto.Tipo
        );

        await _repository.AddAsync(proveedor);
        return proveedor.Id;
    }
}

}
