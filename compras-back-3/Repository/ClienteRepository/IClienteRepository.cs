using compras_back_3.Models;

namespace compras_back_3.Repository.ClienteRepository
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);

        Task<Cliente> GetClienteByNameAsync(string name);
        Task AddClienteAsync(Cliente cliente);
        Task<int> UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);

        Task<List<ClienteArticulo>> GetAllClientesArticulosAsync();
        Task<ClienteArticulo> GetClienteArticuloByIdAsync(int id);
        Task AddClienteArticuloAsync(ClienteArticulo clienteArticulo);
        Task UpdateClienteArticuloAsync(ClienteArticulo clienteArticulo);
        Task DeleteClienteArticuloAsync(int id);
    }
}
