using Proyecto.Models;

namespace Proyecto.Repositories.Contracts
{
    public interface ITarifaRepository
    {
        int Add(Tarifa tarifa); // POST /tarifas
        IEnumerable<Tarifa> GetByFuncionId(int funcionId); // GET /funciones/{funcionId}/tarifas
        Tarifa GetById(int id); // GET /tarifas/{tarifaId}
        bool Update(Tarifa tarifa); // PUT /tarifas/{tarifaId}
    }
}
