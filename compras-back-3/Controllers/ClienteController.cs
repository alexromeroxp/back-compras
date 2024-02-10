using compras_back_3.Models;
using compras_back_3.Services.ClientesService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace compras_back_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> AddCliente(Cliente cliente)
        {
            await _clienteService.AddClienteAsync(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            try
            {
                await _clienteService.UpdateClienteAsync(cliente);
            }
            catch (Exception e)
            {
               return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteService.DeleteClienteAsync(id);

            return NoContent();
        }

        [HttpGet("Cliente-Articulo")]
        public async Task<ActionResult<List<ClienteArticulo>>> GetAllClientesArticulos()
        {
            var clientesArticulos = await _clienteService.GetAllClientesArticulosAsync();
            return Ok(clientesArticulos);
        }

        [HttpPost("Cliente-Articulo")]
        public async Task<ActionResult<ClienteArticulo>> AddClienteArticulo(ClienteArticulo clienteArticulo)
        {
            await _clienteService.AddClienteArticuloAsync(clienteArticulo);
            return CreatedAtAction(nameof(GetAllClientesArticulos), clienteArticulo);
        }

        [HttpPut("Cliente-Articulo/{id}")]
        public async Task<IActionResult> UpdateClienteArticulo(int id, ClienteArticulo clienteArticulo)
        {
            try
            {
                await _clienteService.UpdateClienteArticuloAsync(clienteArticulo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpDelete("Cliente-Articulo/{id}")]
        public async Task<IActionResult> DeleteClienteArticulo(int id)
        {
            var clienteArticulo = await _clienteService.GetClienteArticuloByIdAsync(id);
            if (clienteArticulo == null)
            {
                return NotFound();
            }

            await _clienteService.DeleteClienteArticuloAsync(id);

            return NoContent();
        }
    }

}
