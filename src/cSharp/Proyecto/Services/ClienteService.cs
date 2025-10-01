using Proyecto.DTOs;
using Proyecto.Models;
using Proyecto.Repositories.Contracts;
using Proyecto.Services.Contracts;

namespace Proyecto.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<ClienteDto> ObtenerTodo()
        {
            return _clienteRepository.GetAll()
                .Select(cliente => new ClienteDto
                {
                    IdCliente = cliente.IdCliente,
                    DNI = cliente.DNI,
                    Nombre = cliente.Nombre,
                    Telefono = cliente.Telefono
                })
                .ToList();
        }
        public Cliente? ObtenerPorId(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public int AgregarCliente(ClienteCreateDto cliente)
        {
            
            var nuevoCliente = new Cliente
            {
                DNI = cliente.DNI,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono
            };
            return _clienteRepository.Add( nuevoCliente);
        }

      // Actualizar cliente
        public bool ActualizarCliente(int id, ClienteUpdateDto cliente )
        {
            var clienteExistente = _clienteRepository.GetById(id);
            if (clienteExistente == null) return false;

            clienteExistente.DNI = cliente.DNI;
            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Telefono = cliente.Telefono;

            return _clienteRepository.Update(id, clienteExistente);
        }
        public bool EliminarCliente(int id)
        {
            return _clienteRepository.Delete(id);
        }
    }
}