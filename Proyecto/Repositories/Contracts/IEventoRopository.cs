using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Interfaces
{
    public interface IEventoRepository
    {
        int Add(Evento evento);
        List<Evento> GetAll();
        Evento? GetById(int id);
        bool Update(Evento evento);
        bool Publicar(int id);
        bool Cancelar(int id);
    }
}
