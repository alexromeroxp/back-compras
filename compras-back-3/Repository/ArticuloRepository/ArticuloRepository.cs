using compras_back_3.Context;
using compras_back_3.Models;
using Microsoft.EntityFrameworkCore;

namespace compras_back_3.Repository.ArticuloRepository
{


    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Articulo>> GetAllArticulosAsync()
        {
            return await _context.Articulos.ToListAsync();
        }

        public async Task<Articulo> GetArticuloByIdAsync(int id)
        {
            return await _context.Articulos.FindAsync(id);
        }

        public async Task AddArticuloAsync(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArticuloAsync(Articulo articulo)
        {
            _context.Entry(articulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticuloAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ArticuloTienda>> GetAllArticulosTiendasAsync()
        {
            var articulosTiendas = await _context.ArticulosTiendas.ToListAsync();

            foreach (var articuloTienda in articulosTiendas)
            {
                if (articuloTienda.ArticuloId != null)
                {
                    articuloTienda.Articulo = await _context.Articulos.FindAsync(articuloTienda.ArticuloId);
                }

                if (articuloTienda.TiendaId != null)
                {
                    articuloTienda.Tienda = await _context.Tiendas.FindAsync(articuloTienda.TiendaId);
                }
            }

            return articulosTiendas;
        }

        public async Task<ArticuloTienda> GetArticuloTiendaByIdAsync(int id)
        {
            return await _context.ArticulosTiendas.FindAsync(id);
        }

        public async Task AddArticuloTiendaAsync(ArticuloTienda articuloTienda)
        {
            _context.ArticulosTiendas.Add(articuloTienda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArticuloTiendaAsync(ArticuloTienda articuloTienda)
        {
            _context.Entry(articuloTienda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticuloTiendaAsync(int id)
        {
            var articuloTienda = await _context.ArticulosTiendas.FindAsync(id);
            _context.ArticulosTiendas.Remove(articuloTienda);
            await _context.SaveChangesAsync();
        }
    }

}
