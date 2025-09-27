using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Repositories.Contracts;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FuncionesController : ControllerBase
    {
        private readonly IFuncionRepository _repo;

        public FuncionesController(IFuncionRepository repo)
        {
            _repo = repo;
        }

        // POST /funciones
        [HttpPost]
        public ActionResult<int> CrearFuncion(Funcion funcion)
        {
            int id = _repo.Add(funcion);
            return CreatedAtAction(nameof(DetalleFuncion), new { funcionId = id }, new { Id = id });
        }

        // GET /funciones
        [HttpGet]
        public ActionResult<IEnumerable<Funcion>> ListarFunciones()
        {
            return Ok(_repo.GetAll());
        }

        // GET /funciones/{funcionId}
        [HttpGet("{funcionId}")]
        public ActionResult<Funcion> DetalleFuncion(int funcionId)
        {
            var funcion = _repo.GetById(funcionId);
            if (funcion == null) return NotFound();
            return Ok(funcion);
        }

        // PUT /funciones/{funcionId}
        [HttpPut("{funcionId}")]
        public ActionResult ActualizarFuncion(int funcionId, Funcion funcion)
        {
            funcion.IdFuncion = funcionId;
            bool actualizado = _repo.Update(funcion);
            return actualizado ? Ok() : NotFound();
        }

        // POST /funciones/{funcionId}/cancelar
        [HttpPost("{funcionId}/cancelar")]
        public ActionResult CancelarFuncion(int funcionId)
        {
            bool cancelado = _repo.Cancelar(funcionId);
            return cancelado ? Ok("Función cancelada") : NotFound();
        }
    }
}
