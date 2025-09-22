using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Data;
using System.Collections.Generic;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _repo;

        public ClienteController(ClienteRepository repo)
        {
            _repo = repo;
        }

        private string EncriptarHash256(string texto)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(texto);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        [HttpPost]
        public ActionResult<Cliente> CrearCliente([FromBody] Cliente cliente)
        {

            cliente.Nombre = EncriptarHash256(cliente.Nombre) ;
            _repo.Add(cliente);
            return CreatedAtAction(nameof(DetalleCliente), new { clienteId = cliente.IdCliente }, cliente);
        }

        [HttpGet]
        public ActionResult<List<Cliente>> ListarClientes() => Ok(_repo.GetAll());

        [HttpGet("{clienteId}")]
        public ActionResult<Cliente> DetalleCliente(int clienteId)
        {
            var cliente = _repo.GetById(clienteId);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPut("{clienteId}")]
        public IActionResult ActualizarCliente(int clienteId, [FromBody] Cliente cliente)
        {
            if (!_repo.Update(clienteId, cliente)) return NotFound();
            return NoContent();
        }
    }
}
