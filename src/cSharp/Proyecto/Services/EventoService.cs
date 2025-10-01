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
            var evento = _eventoRepository.GetAll();
            return evento.Select(evento => new Evento
            {
                IdEvento = evento.IdEvento,
                Nombre = evento.Nombre,
                Descripcion = evento.Descripcion,
                FechaInicio = evento.FechaInicio,
                FechaFin = evento.FechaFin,
                Estado = evento.Estado
            }).ToList();
        }

        public Evento? ObtenerPorId(int id)
        {
            var evento = _eventoRepository.GetById(id);
            if (evento == null) return null;
            return new Evento
            {
                IdEvento = evento.IdEvento,
                Nombre = evento.Nombre,
                Descripcion = evento.Descripcion,
                FechaInicio = evento.FechaInicio,
                FechaFin = evento.FechaFin,
                Estado = evento.Estado
            };
        }

        public int AgregarEvento(EventoCreateDto evento)
        {
            var nuevoEvento = new Evento
            {
                Nombre = evento.Nombre,
                Descripcion = evento.Descripcion,
                FechaInicio = evento.FechaInicio,
                FechaFin = evento.FechaFin,
                Estado = EstadoEvento.Inactivo
            };
            return _eventoRepository.Add(nuevoEvento);
        }
            public bool ActualizarEvento(int id, EventoUpdateDto evento)
            {
            var entidadEvento = new Evento
            {
            IdEvento = id,
            Nombre = evento.Nombre,
            Descripcion = evento.Descripcion,
            FechaInicio = evento.FechaInicio,
            FechaFin = evento.FechaFin,
            Estado = evento.Estado
            };
    return _eventoRepository.Update(id, entidadEvento);
}

        public bool EliminarEvento(int id)
        {
            return _eventoRepository.Delete(id);
        }

        public bool Publicar(int id)
        {
            var evento = _eventoRepository.GetById(id);
            if (evento == null) return false;

            evento.Estado = EstadoEvento.Publicado;
            return _eventoRepository.Update(id, evento);
        }

        public bool Cancelar(int id)
        {
            var evento = _eventoRepository.GetById(id);
            if (evento == null) return false;

            evento.Estado = EstadoEvento.Cancelado;
            return _eventoRepository.Update(id, evento);
        }
    }
}
