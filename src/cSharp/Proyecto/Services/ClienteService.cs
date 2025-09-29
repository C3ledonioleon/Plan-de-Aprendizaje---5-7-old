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

        public List<Cliente> ObtenerTodo()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente? ObtenerPorId(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public int AgregarCliente(Cliente cliente)
        {
            return _clienteRepository.Add(cliente);
        }

        public bool ActualizarCliente(int id, Cliente cliente)
        {
            return _clienteRepository.Update(id, cliente);
        }

        public bool EliminarCliente(int id)
        {
            return _clienteRepository.Delete(id);
        }
    }
}