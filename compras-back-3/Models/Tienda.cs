using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace compras_back_3.Models
{
    public class Tienda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TiendaId { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }
        public ICollection<Articulo>? Articulos { get; set; }

    }
}
