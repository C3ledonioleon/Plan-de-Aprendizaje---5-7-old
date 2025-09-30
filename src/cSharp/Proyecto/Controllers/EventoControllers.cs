using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Services.Contracts;
using Proyecto.DTOs;
namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        // POST /eventos — Crea un Evento
        [HttpPost]
        public IActionResult CrearEvento([FromBody] EventoCreateDto dto)
        {
            var id = _eventoService.AgregarEvento(dto);
            return CreatedAtAction(nameof(ObtenerEvento), new { eventoId = id }, dto);
        }

        // GET /eventos — Lista eventos
        [HttpGet]
        public IActionResult ObtenerEventos()
        {
            var eventos = _eventoService.ObtenerTodo();
            return Ok(eventos);
        }

        // GET /eventos/{eventoId} — Detalle de un evento
        [HttpGet("{eventoId}")]
        public IActionResult ObtenerEvento(int eventoId)
        {
            var evento = _eventoService.ObtenerPorId(eventoId);
            if (evento == null) return NotFound();
            return Ok(evento);
        }

        // PUT /eventos/{eventoId} — Actualiza datos del evento
        [HttpPut("{eventoId}")]
        public IActionResult ActualizarEvento(int eventoId, [FromBody] Evento evento)
        {
            var actualizado = _eventoService.ActualizarEvento(eventoId, evento);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        // DELETE /eventos/{eventoId} — Elimina un evento
        [HttpDelete("{eventoId}")]
        public IActionResult EliminarEvento(int eventoId)
        {
            var eliminado = _eventoService.EliminarEvento(eventoId);
            if (!eliminado) return NotFound();
            return NoContent();
        }

        // POST /eventos/{eventoId}/publicar — Publica un evento
        [HttpPost("{eventoId}/publicar")]
        public IActionResult PublicarEvento(int eventoId)
        {
            var publicado = _eventoService.Publicar(eventoId);
            if (!publicado) return NotFound();
            return Ok(new { mensaje = "Evento publicado correctamente" });
        }

        // POST /eventos/{eventoId}/cancelar — Cancela un evento
        [HttpPost("{eventoId}/cancelar")]
        public IActionResult CancelarEvento(int eventoId)
        {
            // 👇 No existe Cancelar en tu interfaz, pero podés implementarlo reutilizando ActualizarEvento
            var evento = _eventoService.ObtenerPorId(eventoId);
            if (evento == null) return NotFound();

            evento.Estado = EstadoEvento.Cancelado; // suponiendo que tenés un campo Estado
            var actualizado = _eventoService.ActualizarEvento(eventoId, evento);

            if (!actualizado) return BadRequest();
            return Ok(new { mensaje = "Evento cancelado correctamente" });
        }
    }
}
