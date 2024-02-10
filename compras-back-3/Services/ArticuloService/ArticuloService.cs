using compras_back_3.Models;
using compras_back_3.Repository.ArticuloRepository;

namespace compras_back_3.Services.ArticuloService
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _articuloRepository;

        public ArticuloService(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public async Task<List<Articulo>> GetAllArticulosAsync()
        {
            return await _articuloRepository.GetAllArticulosAsync();
        }

        public async Task<Articulo> GetArticuloByIdAsync(int id)
        {
            return await _articuloRepository.GetArticuloByIdAsync(id);
        }

        public async Task AddArticuloAsync(Articulo articulo)
        {
            await _articuloRepository.AddArticuloAsync(articulo);
        }

        public async Task UpdateArticuloAsync(Articulo articulo)
        {
            await _articuloRepository.UpdateArticuloAsync(articulo);
        }

        public async Task DeleteArticuloAsync(int id)
        {
            await _articuloRepository.DeleteArticuloAsync(id);
        }



        public async Task<List<ArticuloTienda>> GetAllArticulosTiendasAsync()
        {
            return await _articuloRepository.GetAllArticulosTiendasAsync();
        }

        public async Task<ArticuloTienda> GetArticuloTiendaByIdAsync(int id)
        {
            return await _articuloRepository.GetArticuloTiendaByIdAsync(id);
        }

        public async Task AddArticuloTiendaAsync(ArticuloTienda articuloTienda)
        {
            await _articuloRepository.AddArticuloTiendaAsync(articuloTienda);
        }

        public async Task UpdateArticuloTiendaAsync(ArticuloTienda articuloTienda)
        {
            await _articuloRepository.UpdateArticuloTiendaAsync(articuloTienda);
        }

        public async Task DeleteArticuloTiendaAsync(int id)
        {
            await _articuloRepository.DeleteArticuloTiendaAsync(id);
        }
    }
}
