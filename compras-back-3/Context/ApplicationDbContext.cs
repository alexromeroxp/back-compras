using compras_back_3.Models;
using Microsoft.EntityFrameworkCore;

namespace compras_back_3.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<ArticuloTienda> ArticulosTiendas { get; set; }
        public DbSet<ClienteArticulo> ClientesArticulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloTienda>()
                .HasKey(at => new { at.ArticuloId, at.TiendaId });

            modelBuilder.Entity<ArticuloTienda>()
                .HasOne(at => at.Articulo)
                .WithMany()
                .HasForeignKey(at => at.ArticuloId);

            modelBuilder.Entity<ArticuloTienda>()
                .HasOne(at => at.Tienda)
                .WithMany()
                .HasForeignKey(at => at.TiendaId);

            modelBuilder.Entity<ClienteArticulo>()
                .HasKey(ca => new { ca.ClienteId, ca.ArticuloId });

            modelBuilder.Entity<ClienteArticulo>()
                .HasOne(ca => ca.Cliente)
                .WithMany()
                .HasForeignKey(ca => ca.ClienteId);

            modelBuilder.Entity<ClienteArticulo>()
                .HasOne(ca => ca.Articulo)
                .WithMany()
                .HasForeignKey(ca => ca.ArticuloId);
        }


    }

}
