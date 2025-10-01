using Microsoft.AspNetCore.Mvc;
using Proyecto.DTOs;
using Proyecto.Services.Contracts;
using System.Linq;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TarifasController : ControllerBase
    {
        private readonly ITarifaService _tarifaService;

        public TarifasController(ITarifaService tarifaService)
        {
            _tarifaService = tarifaService;
        }

        // POST /tarifas — Crea una Tarifa
        [HttpPost]
        public IActionResult CrearTarifa([FromBody] TarifaCreateDto dto)
        {
            var id = _tarifaService.AgregarTarifa(dto);
            return CreatedAtAction(nameof(ObtenerTarifa), new { tarifaId = id }, dto);
        }

        // GET /tarifas — Lista todas las tarifas
        [HttpGet]
        public IActionResult ObtenerTarifas()
        {
            var tarifas = _tarifaService.ObtenerTodo();
            return Ok(tarifas);
        }

        // GET /tarifas/{tarifaId} — Detalle de tarifa
        [HttpGet("{tarifaId}")]
        public IActionResult ObtenerTarifa(int tarifaId)
        {
            var tarifa = _tarifaService.ObtenerPorId(tarifaId);
            if (tarifa == null) return NotFound();
            return Ok(tarifa);
        }

        // PUT /tarifas/{tarifaId} — Actualiza precio, stock o estado
        [HttpPut("{tarifaId}")]
        public IActionResult ActualizarTarifa(int tarifaId, [FromBody] TarifaUpdateDto dto)
        {
            var actualizado = _tarifaService.ActualizarTarifa(tarifaId, dto);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        // DELETE /tarifas/{tarifaId} — Elimina una tarifa
        [HttpDelete("{tarifaId}")]
        public IActionResult EliminarTarifa(int tarifaId)
        {
            var eliminado = _tarifaService.EliminarTarifa(tarifaId);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}
