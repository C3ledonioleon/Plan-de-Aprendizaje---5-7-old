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

        public List<Cliente> GetAllClientes()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente? GetClienteById(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public int CreateCliente(Cliente cliente)
        {
            return _clienteRepository.Add(cliente);
        }

        public bool UpdateCliente(int id, Cliente cliente)
        {
            return _clienteRepository.Update(id, cliente);
        }

        public bool DeleteCliente(int id)
        {
            return _clienteRepository.Delete(id);
        }
    }
}