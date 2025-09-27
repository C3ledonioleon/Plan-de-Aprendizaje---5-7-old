using Proyecto.Models;

namespace Proyecto.Services.Contracts
{
    public interface IClienteService
    {
        List<Cliente> GetAllClientes();
        Cliente? GetClienteById(int id);
        int CreateCliente(Cliente cliente);
        bool UpdateCliente(int id, Cliente cliente);
        bool DeleteCliente(int id);
    }
}