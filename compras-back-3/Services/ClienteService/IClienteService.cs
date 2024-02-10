using compras_back_3.Models;

namespace compras_back_3.Services.ClientesService
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);

        Task<List<ClienteArticulo>> GetAllClientesArticulosAsync();
        Task<ClienteArticulo> GetClienteArticuloByIdAsync(int id);
        Task AddClienteArticuloAsync(ClienteArticulo clienteArticulo);
        Task UpdateClienteArticuloAsync(ClienteArticulo clienteArticulo);
        Task DeleteClienteArticuloAsync(int id);
    }
}
