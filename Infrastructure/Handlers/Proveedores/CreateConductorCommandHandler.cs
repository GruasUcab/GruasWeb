using MediatR;
using GrúasUCAB.Core.Proveedores.Entities;
using GrúasUCAB.Core.Proveedores.Repositories;
using GrúasUCAB.Core.Proveedores.Commands;
using GrúasUCAB.Core.Keycloak;
using System.Runtime.CompilerServices;

namespace GrúasUCAB.Infrastructure.Handlers.Proveedores
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateConductorCommand, Guid>
    {
        private readonly IConductorRepository _repository;
        private readonly IKeycloakService _keycloakService;

        public CreateUsuarioCommandHandler(IConductorRepository repository, IKeycloakService keycloakService)
        {
            _repository = repository;
            _keycloakService = keycloakService;
        }

        public async Task<Guid> Handle(CreateConductorCommand request, CancellationToken cancellationToken)
        {   
            var defaultRole = "Conductor";
            // Crear el usuario en Keycloak
            var keycloakSub = await _keycloakService.CreateUserWithRoleAsync(
                request.ConductorDTO.Username,
                request.ConductorDTO.Email,
                request.ConductorDTO.Nombre,
                request.ConductorDTO.Apellido,
                request.ConductorDTO.Password,
                new List<string> { defaultRole }
                


                
            );
            
            if (string.IsNullOrEmpty(keycloakSub))
            {
                throw new InvalidOperationException("No se pudo crear el conductor en Keycloak.");
            }

            

            // Crear el usuario en la base de datos local
            var conductor = new Conductor(
                Guid.NewGuid(),
                request.ConductorDTO.Nombre,
                request.ConductorDTO.Apellido,
                request.ConductorDTO.Licencia,
                request.ConductorDTO.Telefono,
                request.ConductorDTO.Activo,
                request.ConductorDTO.ProveedorId,
                request.ConductorDTO.DocumentoIdentidad,

                keycloakSub
                
            );

            await _repository.AddAsync(conductor);   

            return conductor.Id;
        }
    }
}