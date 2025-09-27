using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Services.Contracts;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClientesController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        // POST /clientes
        [HttpPost]
        public ActionResult<Cliente> CrearCliente(Cliente cliente)
        {
            int id = clienteService.CreateCliente(cliente);
            return CreatedAtAction(nameof(GetCliente), new { clienteId = id }, cliente);
        }

        // GET /clientes
        [HttpGet]
        public ActionResult<List<Cliente>> GetClientes()
        {
            return Ok(clienteService.GetAllClientes());
        }

        // GET /clientes/{clienteId}
        [HttpGet("{clienteId}")]
        public ActionResult<Cliente> GetCliente(int clienteId)
        {
            var cliente = clienteService.GetClienteById(clienteId);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        // PUT /clientes/{clienteId}
        [HttpPut("{clienteId}")]
        public ActionResult ActualizarCliente(int clienteId, Cliente cliente)
        {
            bool actualizado = clienteService.UpdateCliente(clienteId, cliente);
            if (!actualizado) return NotFound();
            return NoContent();
        }
    }
}
