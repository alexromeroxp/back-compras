using compras_back_3.Models;
using compras_back_3.Services.TiendaService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace compras_back_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendaController : ControllerBase
    {
        private readonly ITiendaService _tiendaService;

        public TiendaController(ITiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tienda>>> GetAllTiendas()
        {
            var tiendas = await _tiendaService.GetAllTiendasAsync();
            return Ok(tiendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tienda>> GetTiendaById(int id)
        {
            var tienda = await _tiendaService.GetTiendaByIdAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }
            return tienda;
        }

        [HttpPost]
        public async Task<ActionResult<Tienda>> AddTienda(Tienda tienda)
        {
            await _tiendaService.AddTiendaAsync(tienda);
            return CreatedAtAction(nameof(GetTiendaById), new { id = tienda.TiendaId }, tienda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTienda(int id, Tienda tienda)
        {
            if (id != tienda.TiendaId)
            {
                return BadRequest();
            }

            try
            {
                await _tiendaService.UpdateTiendaAsync(tienda);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTienda(int id)
        {
            var tienda = await _tiendaService.GetTiendaByIdAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }

            await _tiendaService.DeleteTiendaAsync(id);

            return NoContent();
        }
    }

}
