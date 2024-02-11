using compras_back_3.Context;
using compras_back_3.Models;
using Microsoft.EntityFrameworkCore;

namespace compras_back_3.Repository.ClienteRepository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            var articulosClientes = await GetAllClientesArticulosAsync();

            var clientes = await _context.Clientes
                .ToListAsync();

            foreach (var cliente in clientes)
            {
                cliente.Carrito = articulosClientes
                    .Where(ac => ac.ClienteId == cliente.ClienteId)
                    .Select(ac => new Carrito { Cantidad = ac.Cantidad, Articulo = ac.Articulo })
                    .ToList();
            }

            return clientes;
        }


        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                var articulosClientes = await GetAllClientesArticulosAsync();

                cliente.Carrito = articulosClientes
                    .Where(ac => ac.ClienteId == cliente.ClienteId)
                    .Select(ac => new Carrito { Cantidad = ac.Cantidad, Articulo = ac.Articulo })
                    .ToList();
            }

            return cliente;
        }

        public async Task<Cliente> GetClienteByNameAsync(string name)
        {

            var cliente = await _context.Set<Cliente>().FirstOrDefaultAsync(cliente => cliente.Nombre == name);
            if (cliente != null)
            {
                var articulosClientes = await GetAllClientesArticulosAsync();

                cliente.Carrito = articulosClientes
                    .Where(ac => ac.ClienteId == cliente.ClienteId)
                    .Select(ac => new Carrito { Cantidad = ac.Cantidad, Articulo = ac.Articulo })
                    .ToList();
            }

            return cliente;
        }
        public async Task AddClienteAsync(Cliente cliente)
        {
            if (await _context.Clientes.AnyAsync(c => c.Nombre == cliente.Nombre))
            {
                throw new InvalidOperationException("El nombre de cliente ya está registrado.");
            }

            _context.Set<Cliente>().Add(cliente);
            await _context.SaveChangesAsync();
        }


        public async Task<int> UpdateClienteAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _context.Set<Cliente>().FindAsync(id);
            _context.Set<Cliente>().Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClienteArticulo>> GetAllClientesArticulosAsync()
        {
            var clientesArticulos = await _context.ClientesArticulos.ToListAsync();

            foreach (var clienteArticulo in clientesArticulos)
            {
                if (clienteArticulo.ArticuloId != null)
                {
                    clienteArticulo.Articulo = await _context.Articulos.FindAsync(clienteArticulo.ArticuloId);
                }

                if (clienteArticulo.ClienteId != null)
                {
                    clienteArticulo.Cliente = await _context.Clientes.FindAsync(clienteArticulo.ClienteId);
                }
            }

            return clientesArticulos;
        }
        public async Task<ClienteArticulo> GetClienteArticuloByIdAsync(int id)
        {
            return await _context.ClientesArticulos.FindAsync(id);
        }

        public async Task AddClienteArticuloAsync(ClienteArticulo clienteArticulo)
        {
            var articuloExistente = await _context.Articulos.FindAsync(clienteArticulo.ArticuloId);
            if (articuloExistente == null)
            {
                throw new ArgumentException("El artículo especificado no existe.");
            }

            var clienteExistente = await _context.Clientes.FindAsync(clienteArticulo.ClienteId);
            if (clienteExistente == null)
            {
                throw new ArgumentException("El cliente especificado no existe.");
            }

            _context.ClientesArticulos.Add(clienteArticulo);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateClienteArticuloAsync(ClienteArticulo clienteArticulo)
        {
            _context.Entry(clienteArticulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteArticuloAsync(int id)
        {
            var clienteArticulo = await _context.ClientesArticulos.FindAsync(id);
            _context.ClientesArticulos.Remove(clienteArticulo);
            await _context.SaveChangesAsync();
        }
    }
}
