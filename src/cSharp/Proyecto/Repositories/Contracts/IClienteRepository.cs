using Proyecto.Models;

namespace Proyecto.Repositories.Contracts
{
    public interface IClienteRepository
    {
        List<Cliente> GetAll();
        Cliente? GetById(int id);
        int Add(Cliente cliente);
        bool Update(int id, Cliente cliente);
        bool Delete(int id);
    }
}