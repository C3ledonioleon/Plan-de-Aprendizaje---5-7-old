using Proyecto.DTOs;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Services.Contracts
{
    public interface IEventoService
    {
        List<Evento> ObtenerTodo();
        Evento? ObtenerPorId(int id);
        int AgregarEvento(EventoCreateDto evento);
        bool ActualizarEvento(int id, Evento evento);
        bool EliminarEvento(int id);
        bool Publicar(int Id);
    }
}