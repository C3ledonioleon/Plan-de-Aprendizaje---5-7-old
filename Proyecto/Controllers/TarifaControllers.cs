using Microsoft.AspNetCore.Mvc;
using Proyecto.Data;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifasController : ControllerBase
    {
        private readonly TarifaRepository _repo;

        public TarifasController(TarifaRepository repo)
        {
            _repo = repo;
        }

        // POST /tarifas
        [HttpPost]
        public ActionResult<Tarifa> CrearTarifa(Tarifa tarifa)
        {
            int id = _repo.Add(tarifa);
            return CreatedAtAction(nameof(GetTarifa), new { tarifaId = id }, tarifa);
        }

        // GET /funciones/{funcionId}/tarifas
        [HttpGet("/funciones/{funcionId}/tarifas")]
        public ActionResult<List<Tarifa>> GetTarifasPorFuncion(int funcionId)
        {
            return Ok(_repo.GetByFuncion(funcionId));
        }

        // GET /tarifas/{tarifaId}
        [HttpGet("{tarifaId}")]
        public ActionResult<Tarifa> GetTarifa(int tarifaId)
        {
            var tarifa = _repo.GetById(tarifaId);
            if (tarifa == null) return NotFound();
            return Ok(tarifa);
        }

        // PUT /tarifas/{tarifaId}
        [HttpPut("{tarifaId}")]
        public ActionResult ActualizarTarifa(int tarifaId, Tarifa tarifa)
        {
            bool exito = _repo.Update(tarifaId, tarifa);
            if (!exito) return NotFound();
            return NoContent();
        }
    }
}
