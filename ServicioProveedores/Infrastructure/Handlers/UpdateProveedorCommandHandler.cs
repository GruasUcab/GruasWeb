using MediatR;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Commands;
using GrúasUCAB.Core.Proveedores.Entities;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
    public class UpdateProveedorCommandHandler : IRequestHandler<UpdateProveedorCommand, Unit>
{
    private readonly IProveedorRepository _repository;

    public UpdateProveedorCommandHandler(IProveedorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateProveedorCommand request, CancellationToken cancellationToken)
    {
        var proveedor = await _repository.GetByIdAsync(request.ProveedorDto.Id);

        if (proveedor == null)
            throw new Exception("Proveedor no encontrado");

        proveedor.Update(
            request.ProveedorDto.Nombre,
            request.ProveedorDto.Direccion,
            request.ProveedorDto.Telefono,
            request.ProveedorDto.Email
        );

        await _repository.UpdateAsync(proveedor);
        return Unit.Value;
    }
}

}
