using Xunit;
using Moq;
using Proyecto.Interfaces;
using Proyecto.Controllers;
using Proyecto.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

public class ClientesControllerTests
{
    [Fact]
    public void GetAll_ReturnsListOfClientes()
    {
        // 1. Crear repositorio simulado (mock)
        var mockRepo = new Mock<IClienteRepository>();
        mockRepo.Setup(repo => repo.Add())
                .Returns(new List<Cliente> {
                    new Cliente { Id=1, Nombre="Juan", DNI="123", Email="juan@mail.com", Telefono="111111" },
                    new Cliente { Id=2, Nombre="Ana", DNI="456", Email="ana@mail.com", Telefono="222222" }
                });

        // 2. Crear controlador con el mock
        var controller = new ClientesController(mockRepo.Object);

        // 3. Ejecutar acción
        var result = controller.GetAll();

        // 4. Verificar resultados
        Assert.NotNull(result);
        Assert.Equal(2, ((List<Cliente>)result).Count);
    }

    [Fact]
    public void GetById_ExistingId_ReturnsCliente()
    {
        var mockRepo = new Mock<IClienteRepository>();
        mockRepo.Setup(repo => repo.GetById(1))
                .Returns(new Cliente { Id=1, Nombre="Juan", DNI="123", Email="juan@mail.com", Telefono="111111" });

        var controller = new ClientesController(mockRepo.Object);

        var result = controller.Get(1);

        Assert.NotNull(result);
        Assert.Equal("Juan", result.Nombre);
    }
}
