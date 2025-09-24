using Proyecto.Models;
using System.Collections.Generic;
using Proyecto.Repositories.Contracts;

namespace Proyecto.Repositories.Contratcs
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