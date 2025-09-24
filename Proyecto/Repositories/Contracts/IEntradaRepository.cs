using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Interfaces
{
    public interface IEntradaRepository
    {
        List<Entrada> GetAll();
        Entrada? GetById(int id);
        bool Anular(int id);
    }
}
