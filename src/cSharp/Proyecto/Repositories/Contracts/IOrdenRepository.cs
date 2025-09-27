using Proyecto.Models;

namespace Proyecto.Repositories.Contracts
{
    public interface IOrdenRepository
    {
        int Add(Orden orden);
        List<Orden> GetAll();
        Orden? GetById(int id);
        void Pagar(int id, List<Entrada> entradas);
        bool Cancelar(int id);
    }
}
