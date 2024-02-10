using compras_back_3.Models;
using compras_back_3.Repository.ClienteRepository;

namespace compras_back_3.Services.ClientesService
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllClientesAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _clienteRepository.GetClienteByIdAsync(id);
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            await _clienteRepository.AddClienteAsync(cliente);
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            await _clienteRepository.UpdateClienteAsync(cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteRepository.DeleteClienteAsync(id);
        }


        public async Task<List<ClienteArticulo>> GetAllClientesArticulosAsync()
        {
            return await _clienteRepository.GetAllClientesArticulosAsync();
        }

        public async Task<ClienteArticulo> GetClienteArticuloByIdAsync(int id)
        {
            return await _clienteRepository.GetClienteArticuloByIdAsync(id);
        }

        public async Task AddClienteArticuloAsync(ClienteArticulo clienteArticulo)
        {
            await _clienteRepository.AddClienteArticuloAsync(clienteArticulo);
        }

        public async Task UpdateClienteArticuloAsync(ClienteArticulo clienteArticulo)
        {
            await _clienteRepository.UpdateClienteArticuloAsync(clienteArticulo);
        }

        public async Task DeleteClienteArticuloAsync(int id)
        {
            await _clienteRepository.DeleteClienteArticuloAsync(id);
        }
    }
}
