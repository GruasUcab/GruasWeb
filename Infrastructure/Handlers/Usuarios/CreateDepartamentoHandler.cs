using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;
using MediatR;

namespace GrúasUCAB.Infrastructure.Handlers.Usuarios
{
    public class CreateDepartamentoCommandHandler : IRequestHandler<CreateDepartamentoCommand, Guid>
    {
        private readonly IDepartamentoRepository _repository;

        public CreateDepartamentoCommandHandler(IDepartamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateDepartamentoCommand request, CancellationToken cancellationToken)
        {
            // Proporciona el ID requerido al constructor
            var departamento = new Departamento(
                Guid.NewGuid(), 
                request.DepartamentoDto.Nombre, 
                request.DepartamentoDto.Descripcion
            );

            await _repository.AddAsync(departamento);
            return departamento.Id;
        }
    }
}
