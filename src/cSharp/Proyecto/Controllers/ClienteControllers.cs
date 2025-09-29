using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Services.Contracts;
using Proyecto.DTOs;

namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // POST /clientes — Alta de cliente
        [HttpPost]
        public IActionResult CrearCliente([FromBody] ClienteCreateDto dto)
        {
            var nuevoCliente = new Cliente
            {
                DNI = dto.DNI,
                Nombre = dto.Nombre,
                Telefono = dto.Telefono
            };

            var id = _clienteService.AgregarCliente(nuevoCliente);
            return CreatedAtAction(nameof(ObtenerCliente), new { clienteId = id }, nuevoCliente);
        }

        // GET /clientes — Lista de clientes
        [HttpGet]
        public IActionResult ObtenerClientes()
        {
            var clientes = _clienteService.ObtenerTodo();
            return Ok(clientes);
        }

        // GET /clientes/{clienteId} — Detalle de cliente
        [HttpGet("{clienteId}")]
        public IActionResult ObtenerCliente(int clienteId)
        {
            var cliente = _clienteService.ObtenerPorId(clienteId);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        // PUT /clientes/{clienteId} — Actualiza datos
        [HttpPut("{clienteId}")]
        public IActionResult ActualizarCliente(int clienteId, [FromBody] ClienteCreateDto dto)
        {
            var clienteExistente = _clienteService.ObtenerPorId(clienteId);
            if (clienteExistente == null)
                return NotFound();

            clienteExistente.DNI = dto.DNI;
            clienteExistente.Nombre = dto.Nombre;
            clienteExistente.Telefono = dto.Telefono;

            var actualizado = _clienteService.ActualizarCliente(clienteId, clienteExistente);
            if (!actualizado) return BadRequest();

            return NoContent();
        }
    }
}
