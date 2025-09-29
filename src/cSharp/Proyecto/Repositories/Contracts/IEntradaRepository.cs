using Proyecto.Models;

namespace Proyecto.Repositories.Contracts
{
    public interface IEntradaRepository
    {
        List<Entrada> GetAll();
        Entrada? GetById(int id);
        int Add(Entrada entrada); 
        bool Update(int id, Entrada entrada);
        bool Delete(int id);
    }
}
