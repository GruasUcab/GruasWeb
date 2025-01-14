using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Repositories;
using MediatR;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class UpdateDepartamentoCommandHandler : IRequestHandler<UpdateDepartamentoCommand, Unit>
    {
        private readonly IDepartamentoRepository _repository;

        public UpdateDepartamentoCommandHandler(IDepartamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var departamento = await _repository.GetByIdAsync(request.DepartamentoDto.Id);

            if (departamento == null)
                throw new KeyNotFoundException("Departamento no encontrado.");

                departamento.UpdateNombre(request.DepartamentoDto.Nombre) ;           
                departamento.UpdateDescripcion(request.DepartamentoDto.Ubicacion);

            await _repository.UpdateAsync(departamento);
            return Unit.Value;
        }
    }
}
