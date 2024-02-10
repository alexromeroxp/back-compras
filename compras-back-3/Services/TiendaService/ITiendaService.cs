using compras_back_3.Models;

namespace compras_back_3.Services.TiendaService
{
    public interface ITiendaService
    {
        Task<List<Tienda>> GetAllTiendasAsync();
        Task<Tienda> GetTiendaByIdAsync(int id);
        Task AddTiendaAsync(Tienda tienda);
        Task UpdateTiendaAsync(Tienda tienda);
        Task DeleteTiendaAsync(int id);
    }
}
