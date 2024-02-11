using compras_back_3.Context;
using compras_back_3.Models;
using compras_back_3.Repository;
using compras_back_3.Services;

namespace compras_back_3
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;

                try
                {
                    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

                    if (!dbContext.Clientes.Any() && !dbContext.Tiendas.Any() && !dbContext.Articulos.Any())
                    {
                        dbContext.Clientes.AddRange(
                            new Cliente { Nombre = "Cliente1", Apellidos = "Apellido1", Direccion = "Dirección1" },
                            new Cliente { Nombre = "Cliente2", Apellidos = "Apellido2", Direccion = "Dirección2" },
                            new Cliente { Nombre = "Cliente3", Apellidos = "Apellido3", Direccion = "Dirección3" }
                        );

                        dbContext.Tiendas.AddRange(
                            new Tienda { Sucursal = "Tienda1", Direccion = "DirecciónTienda1" },
                            new Tienda { Sucursal = "Tienda2", Direccion = "DirecciónTienda2" },
                            new Tienda { Sucursal = "Tienda3", Direccion = "DirecciónTienda3" }
                        );

                        dbContext.Articulos.AddRange(
                            new Articulo { Descripcion = "Articulo1", Codigo = "Codigo1", Imagen = "Imagen1", Precio = 10.0, Stock = 100 },
                            new Articulo { Descripcion = "Articulo2", Codigo = "Codigo2", Imagen = "Imagen2", Precio = 15.0, Stock = 50 },
                            new Articulo { Descripcion = "Articulo3", Codigo = "Codigo3", Imagen = "Imagen3", Precio = 20.0, Stock = 75 }
                        );

                        dbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al intentar crear registros iniciales: " + ex.Message);
                }
            }
        }
    }
}
