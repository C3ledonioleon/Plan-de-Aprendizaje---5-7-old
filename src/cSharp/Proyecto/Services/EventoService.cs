using Proyecto.DTOs;
using Proyecto.Models;
using Proyecto.Repositories.Contracts;
using Proyecto.Services.Contracts;

namespace Proyecto.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public List<Evento> ObtenerTodo()
        {
            return _eventoRepository.GetAll();
        }

        public Evento? ObtenerPorId(int id)
        {
            return _eventoRepository.GetById(id);
        }
        public int AgregarEvento(EventoCreateDto evento)
        {
        var  nuevoEvento = new Evento
        {
            Nombre = evento.Nombre,
            Descripcion = evento.Descripcion,
            FechaInicio = evento.FechaInicio,
            FechaFin = evento.FechaFin,
            Estado = EstadoEvento.Inactivo
        };
            return _eventoRepository.Add( nuevoEvento );
        }

        public bool ActualizarEvento(int id, Evento evento)
        {
            return _eventoRepository.Update(id, evento);
        }

        public bool EliminarEvento(int id)
        {
            return _eventoRepository.Delete(id);
        }
        public bool Publicar(int Id)
        {
            var evento = _eventoRepository.GetById(Id);
            evento.Estado = EstadoEvento.Publicado;
            return _eventoRepository.Update(Id, evento);
        }
    }
}