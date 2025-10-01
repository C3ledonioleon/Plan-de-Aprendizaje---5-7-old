using Microsoft.AspNetCore.Mvc;
using Proyecto.DTOs;
using Proyecto.Models;
using Proyecto.Services.Contracts;

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

        [HttpPost]
        public IActionResult CrearEvento([FromBody] EventoCreateDto dto)
        {
            var id = _eventoService.AgregarEvento(dto);
            return CreatedAtAction(nameof(ObtenerEvento), new { eventoId = id }, dto);
        }

        [HttpGet]
        public IActionResult ObtenerEventos()
        {
            var eventos = _eventoService.ObtenerTodo();
            return Ok(eventos);
        }

        [HttpGet("{eventoId}")]
        public IActionResult ObtenerEvento(int eventoId)
        {
            var evento = _eventoService.ObtenerPorId(eventoId);
            if (evento == null) return NotFound();
            return Ok(evento);
        }

        [HttpPut("{eventoId}")]
        public IActionResult ActualizarEvento(int eventoId, [FromBody] EventoUpdateDto dto)
        {
            var actualizado = _eventoService.ActualizarEvento(eventoId, dto);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        [HttpDelete("{eventoId}")]
        public IActionResult EliminarEvento(int eventoId)
        {
            var eliminado = _eventoService.EliminarEvento(eventoId);
            if (!eliminado) return NotFound();
            return NoContent();
        }

        [HttpPost("{eventoId}/publicar")]
        public IActionResult PublicarEvento(int eventoId)
        {
            var publicado = _eventoService.Publicar(eventoId);
            if (!publicado) return NotFound();
            return Ok(new { mensaje = "Evento publicado correctamente" });
        }

        [HttpPost("{eventoId}/cancelar")]
        public IActionResult CancelarEvento(int Id)
        {
            var cancelado = _eventoService.Cancelar( Id);
            if (!cancelado) return NotFound();
            return Ok(new { mensaje = "Evento cancelado correctamente" });
        }
    }
}
