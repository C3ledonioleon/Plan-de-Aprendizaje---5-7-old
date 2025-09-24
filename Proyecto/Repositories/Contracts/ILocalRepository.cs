using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Repositories.Contracts
{
    public interface ILocalRepository
    {
        int Add(Local local);
        IEnumerable<Local> GetAll();
        Local? GetById(int id);
        bool Update(Local local);
        bool Delete(int id);
    }
}
