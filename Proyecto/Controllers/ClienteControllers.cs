using Microsoft.AspNetCore.Mvc;
using Proyecto.Repositories.Contracts;
using Proyecto.Models;
using System.Collections.Generic;
using Proyecto.Repositories.Contratcs;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repo;

        public ClientesController(IClienteRepository repo)
        {
            _repo = repo;
        }

        // POST /clientes
        [HttpPost]
        public ActionResult<Cliente> CrearCliente(Cliente cliente)
        {
            int id = _repo.Add(cliente);
            return CreatedAtAction(nameof(GetCliente), new { clienteId = id }, cliente);
        }

        // GET /clientes
        [HttpGet]
        public ActionResult<List<Cliente>> GetClientes()
        {
            return Ok(_repo.GetAll());
        }

        // GET /clientes/{clienteId}
        [HttpGet("{clienteId}")]
        public ActionResult<Cliente> GetCliente(int clienteId)
        {
            var cliente = _repo.GetById(clienteId);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        // PUT /clientes/{clienteId}
        [HttpPut("{clienteId}")]
        public ActionResult ActualizarCliente(int clienteId, Cliente cliente)
        {
            bool actualizado = _repo.Update(clienteId, cliente);
            if (!actualizado) return NotFound();
            return NoContent();
        }
    }
}
