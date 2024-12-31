using MediatR;
using GrúasUCAB.Core.Proveedores.Commands;
using GrúasUCAB.Core.Proveedores.Repositories;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
    public class DeleteProveedorCommandHandler : IRequestHandler<DeleteProveedorCommand, Unit>
    {
        private readonly IProveedorRepository _repository;

        public DeleteProveedorCommandHandler(IProveedorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProveedorCommand request, CancellationToken cancellationToken)
        {
            var proveedor = await _repository.GetByIdAsync(request.Id);
            if (proveedor == null)
            {
                throw new KeyNotFoundException($"Proveedor con ID {request.Id} no encontrado.");
            }

            await _repository.DeleteAsync(request.Id);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
