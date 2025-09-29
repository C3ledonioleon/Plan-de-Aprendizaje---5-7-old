using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Services.Contracts;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LocalesController : ControllerBase
    {
        private readonly ILocalService _localService;

        public LocalesController(ILocalService localService)
        {
            _localService = localService;
        }

        // POST /locales — Crea un Local
        [HttpPost]
        public IActionResult CrearLocal([FromBody] Local local)
        {
            var id = _localService.AgregarLocal(local);
            return CreatedAtAction(nameof(ObtenerLocal), new { localId = id }, local);
        }

        // GET /locales — Lista de locales
        [HttpGet]
        public IActionResult ObtenerLocales()
        {
            var locales = _localService.ObtenerTodo();
            return Ok(locales);
        }

        // GET /locales/{localId} — Detalle de un local
        [HttpGet("{localId}")]
        public IActionResult ObtenerLocal(int localId)
        {
            var local = _localService.ObtenerPorId(localId);
            if (local == null) return NotFound();
            return Ok(local);
        }

        // PUT /locales/{localId} — Actualiza datos del local
        [HttpPut("{localId}")]
        public IActionResult ActualizarLocal(int localId, [FromBody] Local local)
        {
            var actualizado = _localService.ActualizarLocal(localId, local);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        // DELETE /locales/{localId} — Elimina un local (si no tiene funciones vigentes)
        [HttpDelete("{localId}")]
        public IActionResult EliminarLocal(int localId)
        {
            var eliminado = _localService.EliminarLocal(localId);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}
