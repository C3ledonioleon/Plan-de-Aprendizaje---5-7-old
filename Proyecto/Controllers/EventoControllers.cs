using Microsoft.AspNetCore.Mvc;
using Proyecto.Interfaces;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _repo;

        public EventoController(IEventoRepository repo)
        {
            _repo = repo;
        }

        // POST /eventos
        [HttpPost]
        public IActionResult CrearEvento(Evento evento)
        {
            int id = _repo.Add(evento);
            return CreatedAtAction(nameof(DetalleEvento), new { eventoId = id }, evento);
        }

        // GET /eventos
        [HttpGet]
        public ActionResult<List<Evento>> ListarEventos()
        {
            return Ok(_repo.GetAll());
        }

        // GET /eventos/{eventoId}
        [HttpGet("{eventoId}")]
        public ActionResult<Evento> DetalleEvento(int eventoId)
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
            if (!actualizado) return NotFound();
            return Ok(evento);
        }

        // POST /eventos/{eventoId}/publicar
        [HttpPost("{eventoId}/publicar")]
        public IActionResult PublicarEvento(int eventoId)
        {
            bool publicado = _repo.Publicar(eventoId);
            if (!publicado) return NotFound();
            return Ok(new { mensaje = "Evento publicado" });
        }

        // POST /eventos/{eventoId}/cancelar
        [HttpPost("{eventoId}/cancelar")]
        public IActionResult CancelarEvento(int eventoId)
        {
            bool cancelado = _repo.Cancelar(eventoId);
            if (!cancelado) return NotFound();
            return Ok(new { mensaje = "Evento cancelado" });
        }
    }
}
