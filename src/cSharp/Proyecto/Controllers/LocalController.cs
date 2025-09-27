using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Repositories.Contracts;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LocalController : ControllerBase
    {
        private readonly ILocalRepository _repo;

        public LocalController(ILocalRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult CrearLocal(Local local)
        {
            int id = _repo.Add(local);
            return CreatedAtAction(nameof(GetById), new { id = id }, local);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Local>> GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Local> GetById(int id)
        {
            var local = _repo.GetById(id);
            if (local == null) return NotFound();
            return Ok(local);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarLocal(int id, Local local)
        {
            local.IdLocal = id;
            bool actualizado = _repo.Update(local);
            return actualizado ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarLocal(int id)
        {
            bool eliminado = _repo.Delete(id);
            return eliminado ? Ok() : BadRequest("El local tiene funciones vigentes y no se puede eliminar.");
        }
    }
}
