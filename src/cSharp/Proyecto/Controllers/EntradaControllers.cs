using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Services.Contracts;
using Proyecto.DTOs;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EntradasController : ControllerBase
    {
        private readonly IEntradaService _entradaService;

        public EntradasController(IEntradaService entradaService)
        {
            _entradaService = entradaService;
        }

        // GET /api/entradas
        [HttpGet]
        public ActionResult<List<Entrada>> ObtenerEntradas()
        {
            var entradas = _entradaService.ObtenerTodo();
            return Ok(entradas);
        }

        // GET /api/entradas/{entradaId}
        [HttpGet("{entradaId}")]
        public ActionResult<Entrada> ObtenerEntradaPorId(int entradaId)
        {
            var entrada = _entradaService.ObtenerPorId(entradaId);
            if (entrada == null)
                return NotFound($"No se encontró la entrada con ID {entradaId}");

            return Ok(entrada);
        }

        // POST /api/entradas/{entradaId}/anular
        [HttpPost("{entradaId}/anular")]
        public ActionResult AnularEntrada(int entradaId)
        {
            var entrada = _entradaService.ObtenerPorId(entradaId);
            if (entrada == null)
                return NotFound($"No se encontró la entrada con ID {entradaId}");
                
            entrada.Estado = EstadoEntrada.Anulada; 
            var actualizado = _entradaService.ActualizarEntrada(entradaId, entrada);

            if (!actualizado)
                return StatusCode(500, "No se pudo anular la entrada.");

            return Ok($"La entrada con ID {entradaId} fue anulada correctamente.");
        }
    }
}
