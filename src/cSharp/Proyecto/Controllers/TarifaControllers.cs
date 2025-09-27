using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Repositories.Contracts;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifasController : ControllerBase
    {
        private readonly ITarifaRepository _tarifaRepository;

        public TarifasController(ITarifaRepository tarifaRepository)
        {
            _tarifaRepository = tarifaRepository;
        }

        // POST /tarifas
        [HttpPost]
        public IActionResult Create([FromBody] Tarifa tarifa)
        {
            if (tarifa == null) return BadRequest();

            var id = _tarifaRepository.Add(tarifa);
            return CreatedAtAction(nameof(GetById), new { tarifaId = id }, tarifa);
        }

        // GET /funciones/{funcionId}/tarifas
        [HttpGet("/api/funciones/{funcionId}/tarifas")]
        public IActionResult GetByFuncion(int funcionId)
        {
            var tarifas = _tarifaRepository.GetByFuncionId(funcionId);
            if (tarifas == null || !tarifas.Any()) return NotFound();

            return Ok(tarifas);
        }

        // GET /tarifas/{tarifaId}
        [HttpGet("{tarifaId}")]
        public IActionResult GetById(int tarifaId)
        {
            var tarifa = _tarifaRepository.GetById(tarifaId);
            if (tarifa == null) return NotFound();

            return Ok(tarifa);
        }

        // PUT /tarifas/{tarifaId}
        [HttpPut("{tarifaId}")]
        public IActionResult Update(int tarifaId, [FromBody] Tarifa tarifa)
        {
            if (tarifa == null || tarifa.IdTarifa != tarifaId) return BadRequest();

            var updated = _tarifaRepository.Update(tarifa);
            if (!updated) return NotFound();

            return NoContent();
        }
    }
}
