using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Interfaces
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
