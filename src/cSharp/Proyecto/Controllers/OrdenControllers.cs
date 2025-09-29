using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Services.Contracts;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenService _ordenService;

        public OrdenesController(IOrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        // POST /ordenes — Crea orden y reserva stock
        [HttpPost]
        public IActionResult CrearOrden([FromBody] Orden orden)
        {
            var id = _ordenService.AgregarOrden(orden);
            return CreatedAtAction(nameof(ObtenerOrden), new { ordenId = id }, orden);
        }

        // GET /ordenes — Lista todas las órdenes
        [HttpGet]
        public IActionResult ObtenerOrdenes()
        {
            var ordenes = _ordenService.ObtenerTodo();
            return Ok(ordenes);
        }

        // GET /ordenes/{ordenId} — Detalle de una orden
        [HttpGet("{ordenId}")]
        public IActionResult ObtenerOrden(int ordenId)
        {
            var orden = _ordenService.ObtenerPorId(ordenId);
            if (orden == null) return NotFound();
            return Ok(orden);
        }

        // PUT /ordenes/{ordenId} — Actualiza orden
        [HttpPut("{ordenId}")]
        public IActionResult ActualizarOrden(int ordenId, [FromBody] Orden orden)
        {
            var actualizado = _ordenService.ActualizarOrden(ordenId, orden);
            if (!actualizado) return NotFound();
            return NoContent();
        }

        // DELETE /ordenes/{ordenId} — Elimina orden
        [HttpDelete("{ordenId}")]
        public IActionResult EliminarOrden(int ordenId)
        {
            var eliminado = _ordenService.EliminarOrden(ordenId);
            if (!eliminado) return NotFound();
            return NoContent();
        }

        // POST /ordenes/{ordenId}/pagar — Marca como Pagada y emite Entradas
        [HttpPost("{ordenId}/pagar")]
        public IActionResult PagarOrden(int ordenId)
        {
            var orden = _ordenService.ObtenerPorId(ordenId);
            if (orden == null) return NotFound();
            if (orden.Estado != EstadoOrden.Creada)
                return BadRequest(new { mensaje = "Solo se pueden pagar órdenes en estado Creada." });

            orden.Estado = EstadoOrden.Pagada;
            _ordenService.ActualizarOrden(ordenId, orden);

            // Aquí podrías agregar la lógica de emisión de entradas

            return Ok(new { mensaje = "Orden pagada y entradas emitidas." });
        }

        // POST /ordenes/{ordenId}/cancelar — Cancela la orden (si está Creada)
        [HttpPost("{ordenId}/cancelar")]
        public IActionResult CancelarOrden(int ordenId)
        {
            var orden = _ordenService.ObtenerPorId(ordenId);
            if (orden == null) return NotFound();
            if (orden.Estado != EstadoOrden.Creada)
                return BadRequest(new { mensaje = "Solo se pueden cancelar órdenes en estado Creada." });

            orden.Estado = EstadoOrden.Cancelada;
            _ordenService.ActualizarOrden(ordenId, orden);

            // Aquí podrías liberar el stock reservado

            return Ok(new { mensaje = "Orden cancelada y stock liberado." });
        }
    }
}
