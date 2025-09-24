using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Interfaces;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SectorController : ControllerBase
    {
        private readonly ISectorRepository _repository;

        public SectorController(ISectorRepository repository)
        {
            _repository = repository;
        }

        // POST /locales/{localId}/sectores
        [HttpPost("/locales/{localId}/sectores")]
        public ActionResult<Sector> CrearSector(int localId, Sector sector)
        {
            sector.IdLocal = localId;
            int id = _repository.CrearSector(sector);
            sector.IdSector = id;
            return CreatedAtAction(nameof(GetSectoresPorLocal), new { localId = localId }, sector);
        }

        // GET /locales/{localId}/sectores
        [HttpGet("/locales/{localId}/sectores")]
        public ActionResult<IEnumerable<Sector>> GetSectoresPorLocal(int localId)
        {
            var sectores = _repository.ObtenerSectoresPorLocal(localId);
            return Ok(sectores);
        }

        // PUT /sectores/{sectorId}
        [HttpPut("{sectorId}")]
        public IActionResult ActualizarSector(int sectorId, Sector sector)
        {
            sector.IdSector = sectorId;
            bool actualizado = _repository.ActualizarSector(sector);
            return actualizado ? Ok() : NotFound();
        }

        // DELETE /sectores/{sectorId}
        [HttpDelete("{sectorId}")]
        public IActionResult EliminarSector(int sectorId)
        {
            bool eliminado = _repository.EliminarSector(sectorId);
            return eliminado ? Ok() : BadRequest("No se puede eliminar el sector porque tiene tarifas o funciones asociadas.");
        }
    }
}
