using Proyecto.DTOs;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Services.Contracts
{
    public interface IClienteService
    {
        List<Cliente> ObtenerTodo();            // Antes: GetAll
        Cliente? ObtenerPorId(int id);           // Antes: GetById
        int AgregarCliente(ClienteCreateDto cliente);     // Antes: Add
        bool ActualizarCliente(int id, Cliente cliente); // Antes: Update
        bool EliminarCliente(int id);            // Antes: Delete
    }
}