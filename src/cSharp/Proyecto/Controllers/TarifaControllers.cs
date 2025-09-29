using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Services.Contracts;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api[controller]/[action]")]
    public class TarifasController : ControllerBase
    {
        private readonly ITarifaService _tarifaService;

        public TarifasController(ITarifaService tarifaService)
        {
            _tarifaService = tarifaService;
        }

        // POST /tarifas — Crea una Tarifa
        [HttpPost("tarifas")]
        public IActionResult CrearTarifa(Tarifa tarifa)
        {
            var id = _tarifaService.AgregarTarifa(tarifa);
            return CreatedAtAction(nameof(ObtenerTarifa), new { tarifaId = id }, tarifa);
        }

        // GET /funciones/{funcionId}/tarifas — Lista tarifas de una función
        [HttpGet("funciones/{funcionId}/tarifas")]
        public IActionResult ObtenerTarifas(int funcionId)
        {
            var tarifas = _tarifaService.ObtenerTodo()
                                        .Where(t => t.IdFuncion == funcionId)
                                        .ToList();
            return Ok(tarifas);
        }

        // GET /tarifas/{tarifaId} — Detalle de tarifa
        [HttpGet("tarifas/{tarifaId}")]
        public IActionResult ObtenerTarifa(int tarifaId)
        {
            var tarifa = _tarifaService.ObtenerPorId(tarifaId);
            if (tarifa == null) return NotFound();
            return Ok(tarifa);
        }

        // PUT /tarifas/{tarifaId} — Actualiza precio/stock/estado
        [HttpPut("tarifas/{tarifaId}")]
        public IActionResult ActualizarTarifa(int tarifaId,Tarifa tarifa)
        {
            var actualizado = _tarifaService.ActualizarTarifa(tarifaId, tarifa);
            if (!actualizado) return NotFound();
            return NoContent();
        }
    }
}
        