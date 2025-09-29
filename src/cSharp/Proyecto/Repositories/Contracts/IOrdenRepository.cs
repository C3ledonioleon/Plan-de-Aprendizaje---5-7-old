using Proyecto.Models;

namespace Proyecto.Repositories.Contracts
{
    public interface IOrdenRepository
    {
        List<Orden> GetAll();
        Orden? GetById(int id);
        int Add(Orden orden);
        bool Update(int id, Orden orden);
        bool Delete (int id);
    }
}
