using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Interfaces;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenRepository _repository;

        public OrdenController(IOrdenRepository repository)
        {
            _repository = repository;
        }

        // POST /ordenes
        [HttpPost]
        public ActionResult<Orden> CrearOrden(Orden orden)
        {
            int id = _repository.Add(orden);
            return CreatedAtAction(nameof(GetById), new { ordenId = id }, orden);
        }

        // GET /ordenes
        [HttpGet]
        public ActionResult<List<Orden>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        // GET /ordenes/{ordenId}
        [HttpGet("{ordenId}")]
        public ActionResult<Orden> GetById(int ordenId)
        {
            var orden = _repository.GetById(ordenId);
            if (orden == null)
                return NotFound();
            return Ok(orden);
        }

        // POST /ordenes/{ordenId}/pagar
        [HttpPost("{ordenId}/pagar")]
        public IActionResult PagarOrden(int ordenId, List<Entrada> entradas)
        {
            try
            {
                _repository.Pagar(ordenId, entradas);
                return Ok("Orden pagada y entradas emitidas.");
            }
            catch
            {
                return BadRequest("No se pudo procesar el pago.");
            }
        }

        // POST /ordenes/{ordenId}/cancelar
        [HttpPost("{ordenId}/cancelar")]
        public IActionResult CancelarOrden(int ordenId)
        {
            bool result = _repository.Cancelar(ordenId);
            if (!result)
                return BadRequest("No se pudo cancelar la orden.");
            return Ok("Orden cancelada.");
        }
    }
}
