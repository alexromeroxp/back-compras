using compras_back_3.Context;
using compras_back_3.Repository;
using compras_back_3.Services;

namespace compras_back_3
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración del DbContext
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //// Configuración de repositorios y servicios
            //services.AddScoped<IClienteRepository, ClienteRepository>();
            //services.AddScoped<IClienteService, ClienteService>();

            //// Otros servicios y configuraciones
        }

    }
}
