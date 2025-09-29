using Proyecto.Models;

namespace Proyecto.Services.Contracts
{
    public interface IEventoService
    {
        List<Evento> ObtenerTodo();
        Evento? ObtenerPorId(int id);
        int AgregarEvento(Evento evento);
        bool ActualizarEvento(int id, Evento evento);
        bool EliminarEvento(int id);
        bool Publicar(int Id);
    }
}