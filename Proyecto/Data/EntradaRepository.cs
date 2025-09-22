using Microsoft.AspNetCore.Mvc;
using Proyecto.Data;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntradasController : ControllerBase
    {
        private readonly EntradaRepository _repo;

        public EntradasController(EntradaRepository repo)
        {
            _repo = repo;
        }

        // GET /entradas
        [HttpGet]
        public ActionResult<List<Entrada>> GetEntradas()
        {
            return Ok(_repo.GetAll());
        }

        // GET /entradas/{entradaId}
        [HttpGet("{entradaId}")]
        public ActionResult<Entrada> GetEntrada(int entradaId)
        {
            var entrada = _repo.GetById(entradaId);
            if (entrada == null) return NotFound();
            return Ok(entrada);
        }

        // POST /entradas/{entradaId}/anular
        [HttpPost("{entradaId}/anular")]
        public ActionResult AnularEntrada(int entradaId)
        {
            bool exito = _repo.Anular(entradaId);
            if (!exito) return NotFound();
            return NoContent();
        }
    }
}
