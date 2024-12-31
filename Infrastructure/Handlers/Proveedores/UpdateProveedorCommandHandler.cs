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
            var proveedor = await _repository.GetByIdAsync(request.Id);
            if (proveedor == null)
            {
                throw new KeyNotFoundException($"Proveedor con ID {request.Id} no encontrado.");
            }

            proveedor = new Proveedor(
                request.Id,
                request.Nombre,
                request.Tipo,
                request.Direccion,
                request.Email,
                request.Activo
            );
             
            await _repository.UpdateAsync(proveedor);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
