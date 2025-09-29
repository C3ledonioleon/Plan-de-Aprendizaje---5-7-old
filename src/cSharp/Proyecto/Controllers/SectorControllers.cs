using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Services.Contracts;
using System.Linq;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api[controller]/[action]")]
    public class SectoresController : ControllerBase
    {
        private readonly ISectorService _sectorService;

        public SectoresController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        // POST /locales/{idLocal}/sectores
        [HttpPost("locales/{idLocal}/sectores")]
        public IActionResult CrearSector(int idLocal, Sector sector)
        {
            sector.IdLocal = idLocal;  // ahora usa IdLocal
            var id = _sectorService.AgregarSector(sector);
            return CreatedAtAction(nameof(ObtenerSectores), new { idLocal = idLocal }, sector);
        }

        // GET /locales/{idLocal}/sectores
        [HttpGet("locales/{idLocal}/sectores")]
        public IActionResult ObtenerSectores(int idLocal)
        {
            var sectores = _sectorService.ObtenerTodo()
                .Where(s => s.IdLocal == idLocal)  // ahora usa IdLocal
                .ToList();
            return Ok(sectores);
        }

        // PUT /sectores/{sectorId}
        [HttpPut("sectores/{sectorId}")]
        public IActionResult ActualizarSector(int sectorId, Sector sector)
        {
            var actualizado = _sectorService.ActualizarSector(sectorId, sector);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        // DELETE /sectores/{sectorId}
        [HttpDelete("sectores/{sectorId}")]
        public IActionResult EliminarSector(int sectorId)
        {
            var eliminado = _sectorService.EliminarSector(sectorId);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}
