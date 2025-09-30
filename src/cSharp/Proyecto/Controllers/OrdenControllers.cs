using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Services.Contracts;
using Proyecto.DTOs;

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

        [HttpPost]
        public IActionResult CrearOrden([FromBody] OrdenCreateDto dto)
        {
            var id = _ordenService.AgregarOrden( dto );
            return CreatedAtAction(nameof(ObtenerOrden), new { ordenId = id },  dto);
        }

  
        [HttpGet]
        public IActionResult ObtenerOrdenes()
        {
            var ordenes = _ordenService.ObtenerTodo();
            return Ok(ordenes);
        }


        [HttpGet("{ordenId}")]
        public IActionResult ObtenerOrden(int ordenId)
        {
            var orden = _ordenService.ObtenerPorId(ordenId);
            if (orden == null) return NotFound();
            return Ok(orden);
        }

 
        [HttpPut("{ordenId}")]
        public IActionResult ActualizarOrden(int ordenId, [FromBody] Orden orden)
        {
            var actualizado = _ordenService.ActualizarOrden(ordenId, orden);
            if (!actualizado) return NotFound();
            return NoContent();
        }


        [HttpDelete("{ordenId}")]
        public IActionResult EliminarOrden(int ordenId)
        {
            var eliminado = _ordenService.EliminarOrden(ordenId);
            if (!eliminado) return NotFound();
            return NoContent();
        }

   
        [HttpPost("{ordenId}/pagar")]
        public IActionResult PagarOrden(int ordenId)
        {
            var orden = _ordenService.ObtenerPorId(ordenId);
            if (orden == null) return NotFound();
            if (orden.Estado != EstadoOrden.Creada)
                return BadRequest(new { mensaje = "Solo se pueden pagar órdenes en estado Creada." });

            orden.Estado = EstadoOrden.Pagada;
            _ordenService.ActualizarOrden(ordenId, orden);

 

            return Ok(new { mensaje = "Orden pagada y entradas emitidas." });
        }


        [HttpPost("{ordenId}/cancelar")]
        public IActionResult CancelarOrden(int ordenId)
        {
            var orden = _ordenService.ObtenerPorId(ordenId);
            if (orden == null) return NotFound();
            if (orden.Estado != EstadoOrden.Creada)
                return BadRequest(new { mensaje = "Solo se pueden cancelar órdenes en estado Creada." });

            orden.Estado = EstadoOrden.Cancelada;
            _ordenService.ActualizarOrden(ordenId, orden);



            return Ok(new { mensaje = "Orden cancelada y stock liberado." });
        }
    }
}
