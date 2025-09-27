using Proyecto.Models;

namespace Proyecto.Repositories.Contracts
{
    public interface IFuncionRepository
    {
        int Add(Funcion funcion);
        IEnumerable<Funcion> GetAll();
        Funcion? GetById(int id);
        bool Update(Funcion funcion);
        bool Cancelar(int id);
    }
}
