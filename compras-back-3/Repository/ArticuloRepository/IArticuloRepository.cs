using compras_back_3.Models;

namespace compras_back_3.Repository.ArticuloRepository
{
    public interface IArticuloRepository
    {
        Task<List<Articulo>> GetAllArticulosAsync();
        Task<Articulo> GetArticuloByIdAsync(int id);
        Task AddArticuloAsync(Articulo articulo);
        Task UpdateArticuloAsync(Articulo articulo);
        Task DeleteArticuloAsync(int id);

        Task<List<ArticuloTienda>> GetAllArticulosTiendasAsync();
        Task<ArticuloTienda> GetArticuloTiendaByIdAsync(int id);
        Task AddArticuloTiendaAsync(ArticuloTienda articuloTienda);
        Task UpdateArticuloTiendaAsync(ArticuloTienda articuloTienda);
        Task DeleteArticuloTiendaAsync(int id);
    }
}
