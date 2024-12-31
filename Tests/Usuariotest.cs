using Xunit;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using GrúasUCAB.Core.Usuarios.Commands;
using GrúasUCAB.Core.Usuarios.Entities;
using GrúasUCAB.Core.Usuarios.Repositories;

namespace GrúasUCAB.Tests.Usuarios
{
    public class CreateUsuarioCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateUsuario()
        {
            // Arrange
            var usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            var handler = new CreateUsuarioCommandHandler(usuarioRepositoryMock.Object);

            var command = new CreateUsuarioCommand
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                Email = "juan.perez@example.com",
                Clave = "password123",
                Activo = true,
                TipoUsuario = "Operador",
                DepartamentoId = Guid.NewGuid()
            };

            usuarioRepositoryMock
                .Setup(repo => repo.CreateAsync(It.IsAny<Usuario>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotEqual(Guid.Empty, result); // El resultado debe ser un GUID válido

            usuarioRepositoryMock.Verify(repo => repo.CreateAsync(It.Is<Usuario>(u =>
                u.Nombre == command.Nombre &&
                u.Apellido == command.Apellido &&
                u.Email == command.Email &&
                u.Clave == command.Clave &&
                u.Activo == command.Activo &&
                u.TipoUsuario == command.TipoUsuario &&
                u.DepartamentoId == command.DepartamentoId
            )), Times.Once);
        }
    }
}
