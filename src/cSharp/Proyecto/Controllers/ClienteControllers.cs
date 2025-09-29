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

        // GET /clientes
        [HttpGet]
        public ActionResult<List<Cliente>> GetClientes()
        {
            return Ok(clienteService.ObtenerTodo());
        }

        // GET /clientes/{clienteId}
        [HttpGet("{clienteId}")]
        public ActionResult<Cliente> ObtenerPorId (int clienteId)
        {
            var cliente = clienteService.ObtenerPorId (clienteId);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }
        // POST /clientes
        [HttpPut("{clienteId}")]
        public ActionResult<Cliente> AgregarCliente(Cliente cliente)
        {
            int id = clienteService.AgregarCliente(cliente);
            return CreatedAtAction(nameof(AgregarCliente), new { clienteId = id }, cliente);
        }


        // PUT /clientes/{clienteId}
        [HttpPut("{clienteId}")]
        public ActionResult ActualizarCliente(int Id, Cliente cliente)
        {
            bool actualizado = clienteService.ActualizarCliente( Id, cliente);
            if (!actualizado) return NotFound();
            return NoContent();
        }
    }
}
