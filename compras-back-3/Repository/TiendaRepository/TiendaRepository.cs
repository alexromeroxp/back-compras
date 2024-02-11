using compras_back_3.Context;
using compras_back_3.Models;
using compras_back_3.Repository.ArticuloRepository;
using Microsoft.EntityFrameworkCore;

namespace compras_back_3.Repository.TiendaRepository
{
    public class TiendaRepository : ITiendaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IArticuloRepository _articuloRepository;


        public TiendaRepository(ApplicationDbContext context, IArticuloRepository articuloRepository)
        {
            _context = context;
            _articuloRepository = articuloRepository;
        }

        public async Task<List<Tienda>> GetAllTiendasAsync()
        {
            var articulosTiendas = await _articuloRepository.GetAllArticulosTiendasAsync();

            var tiendas = await _context.Tiendas
                .ToListAsync();

            foreach (var tienda in tiendas)
            {
                tienda.Articulos = articulosTiendas
                    .Where(at => at.TiendaId == tienda.TiendaId)
                    .Select(at => at.Articulo)
                    .ToList();
            }

            return tiendas;
        }

        public async Task<Tienda> GetTiendaByIdAsync(int id)
        {
            return await _context.Tiendas.FindAsync(id);
        }

        public async Task AddTiendaAsync(Tienda tienda)
        {
            _context.Tiendas.Add(tienda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTiendaAsync(Tienda tienda)
        {
            _context.Entry(tienda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTiendaAsync(int id)
        {
            var tienda = await _context.Tiendas.FindAsync(id);
            _context.Tiendas.Remove(tienda);
            await _context.SaveChangesAsync();
        }
    }
}
