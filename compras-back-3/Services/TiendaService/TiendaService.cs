using compras_back_3.Models;
using compras_back_3.Repository.TiendaRepository;

namespace compras_back_3.Services.TiendaService
{
    public class TiendaService : ITiendaService
    {
        private readonly ITiendaRepository _tiendaRepository;

        public TiendaService(ITiendaRepository tiendaRepository)
        {
            _tiendaRepository = tiendaRepository;
        }

        public async Task<List<Tienda>> GetAllTiendasAsync()
        {
            return await _tiendaRepository.GetAllTiendasAsync();
        }

        public async Task<Tienda> GetTiendaByIdAsync(int id)
        {
            return await _tiendaRepository.GetTiendaByIdAsync(id);
        }

        public async Task AddTiendaAsync(Tienda tienda)
        {
            await _tiendaRepository.AddTiendaAsync(tienda);
        }

        public async Task UpdateTiendaAsync(Tienda tienda)
        {
            await _tiendaRepository.UpdateTiendaAsync(tienda);
        }

        public async Task DeleteTiendaAsync(int id)
        {
            await _tiendaRepository.DeleteTiendaAsync(id);
        }
    }
}
