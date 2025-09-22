using Microsoft.AspNetCore.Mvc;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionController : ControllerBase
    {
        private readonly FuncionRepository _repo;

        public FuncionController(FuncionRepository repo)
        {
            _repo = repo;
        }

        // POST /funciones
        [HttpPost]
        public IActionResult CrearFuncion(Funcion funcion)
        {
            int id = _repo.Add(funcion);
            return CreatedAtAction(nameof(DetalleFuncion), new { funcionId = id }, new { Id = id });
        }

        // GET /funciones
        [HttpGet]
        public IActionResult ListarFunciones()
        {
            return Ok(_repo.GetAll());
        }

        // GET /funciones/{funcionId}
        [HttpGet("{funcionId}")]
        public IActionResult DetalleFuncion(int funcionId)
        {
            var funcion = _repo.GetById(funcionId);
            if (funcion == null) return NotFound();
            return Ok(funcion);
        }

        // PUT /funciones/{funcionId}
        [HttpPut("{funcionId}")]
        public IActionResult ActualizarFuncion(int funcionId, Funcion funcion)
        {
            funcion.IdFuncion = funcionId;
            bool actualizado = _repo.Update(funcion);
            return actualizado ? Ok() : NotFound();
        }

        // POST /funciones/{funcionId}/cancelar
        [HttpPost("{funcionId}/cancelar")]
        public IActionResult CancelarFuncion(int funcionId)
        {
            bool cancelado = _repo.Cancelar(funcionId);
            return cancelado ? Ok("Función cancelada") : NotFound();
        }
    }
}
