using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Data
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
