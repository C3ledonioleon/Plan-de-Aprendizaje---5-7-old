using Xunit;
using Moq;
using Aplicacion.Models;
using Aplicacion.Interfaces;
using Aplicacion.Repositories;

namespace Tests
{
    public class ClienteTests
    {
        [Fact]
        public void AddCliente_ShouldReturnNewId()
        {
            // Arrange
            var mockRepo = new Mock<IClienteRepository>();
            mockRepo.Setup(r => r.Add(It.IsAny<Cliente>())).Returns(1);
            var cliente = new Cliente { Nombre = "Juan", DNI = "123", Email = "a@b.com", Telefono = "12345" };

            // Act
            var result = mockRepo.Object.Add(cliente);

            // Assert
            Assert.Equal(1, result);
        }
    }
}
