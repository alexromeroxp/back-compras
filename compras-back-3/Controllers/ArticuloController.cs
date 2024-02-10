using compras_back_3.Models;
using compras_back_3.Services.ArticuloService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace compras_back_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Articulo>>> GetAllArticulos()
        {
            var articulos = await _articuloService.GetAllArticulosAsync();
            return Ok(articulos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticuloById(int id)
        {
            var articulo = await _articuloService.GetArticuloByIdAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            return articulo;
        }

        [HttpPost]
        public async Task<ActionResult<Articulo>> AddArticulo(Articulo articulo)
        {
            await _articuloService.AddArticuloAsync(articulo);
            return CreatedAtAction(nameof(GetArticuloById), new { id = articulo.ArticuloId }, articulo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticulo(int id, Articulo articulo)
        {
            if (id != articulo.ArticuloId)
            {
                return BadRequest();
            }

            try
            {
                await _articuloService.UpdateArticuloAsync(articulo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var articulo = await _articuloService.GetArticuloByIdAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            await _articuloService.DeleteArticuloAsync(id);

            return NoContent();
        }

        [HttpGet("Articulos-Tiendas")]
        public async Task<ActionResult<List<ArticuloTienda>>> GetAllArticulosTiendas()
        {
            var articulosTiendas = await _articuloService.GetAllArticulosTiendasAsync();
            return Ok(articulosTiendas);
        }

        [HttpPost("Articulos-Tiendas")]
        public async Task<ActionResult<ArticuloTienda>> AddArticuloTienda(ArticuloTienda articuloTienda)
        {
            await _articuloService.AddArticuloTiendaAsync(articuloTienda);
            return CreatedAtAction(nameof(GetAllArticulosTiendas), articuloTienda);
        }

        [HttpPut("Articulos-Tiendas/{id}")]
        public async Task<IActionResult> UpdateArticuloTienda(int id, ArticuloTienda articuloTienda)
        {
            try
            {
                await _articuloService.UpdateArticuloTiendaAsync(articuloTienda);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpDelete("Articulos-Tiendas/{id}")]
        public async Task<IActionResult> DeleteArticuloTienda(int id)
        {
            var articuloTienda = await _articuloService.GetArticuloTiendaByIdAsync(id);
            if (articuloTienda == null)
            {
                return NotFound();
            }

            await _articuloService.DeleteArticuloTiendaAsync(id);

            return NoContent();
        }


    }

}
