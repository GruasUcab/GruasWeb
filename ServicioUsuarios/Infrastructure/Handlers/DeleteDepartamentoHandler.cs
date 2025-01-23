using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Repositories;
using MediatR;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class DeleteDepartamentoCommandHandler : IRequestHandler<DeleteDepartamentoCommand, Unit>
    {
        private readonly IDepartamentoRepository _repository;

        public DeleteDepartamentoCommandHandler(IDepartamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var departamento = await _repository.GetByIdAsync(request.Id);

            if (departamento == null)
                throw new KeyNotFoundException("Departamento no encontrado.");

            await _repository.DeleteAsync(departamento);
            return Unit.Value;
        }
    }
}
