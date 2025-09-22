using Microsoft.AspNetCore.Mvc;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly EventoRepository _repo;

        public EventoController(EventoRepository repo)
        {
            _repo = repo;
        }

        // POST /eventos
        [HttpPost]
        public IActionResult CrearEvento(Evento evento)
        {
            int id = _repo.Add(evento);
            return CreatedAtAction(nameof(DetalleEvento), new { eventoId = id }, new { Id = id });
        }

        // GET /eventos
        [HttpGet]
        public IActionResult ListarEventos()
        {
            return Ok(_repo.GetAll());
        }

        // GET /eventos/{eventoId}
        [HttpGet("{eventoId}")]
        public IActionResult DetalleEvento(int eventoId)
        {
            var evento = _repo.GetById(eventoId);
            if (evento == null) return NotFound();
            return Ok(evento);
        }

        // PUT /eventos/{eventoId}
        [HttpPut("{eventoId}")]
        public IActionResult ActualizarEvento(int eventoId, Evento evento)
        {
            evento.IdEvento = eventoId;
            bool actualizado = _repo.Update(evento);
            return actualizado ? Ok() : NotFound();
        }

        // POST /eventos/{eventoId}/publicar
        [HttpPost("{eventoId}/publicar")]
        public IActionResult PublicarEvento(int eventoId)
        {
            bool publicado = _repo.Publicar(eventoId);
            return publicado ? Ok("Evento publicado") : NotFound();
        }

        // POST /eventos/{eventoId}/cancelar
        [HttpPost("{eventoId}/cancelar")]
        public IActionResult CancelarEvento(int eventoId)
        {
            bool cancelado = _repo.Cancelar(eventoId);
            return cancelado ? Ok("Evento cancelado") : NotFound();
        }
    }
}
