using Proyecto.Models;

namespace Proyecto.Repositories.Contracts
{
    public interface IEntradaRepository
    {
        List<Entrada> GetAll();
        Entrada? GetById(int id);
        bool Anular(int id);
    }
}
