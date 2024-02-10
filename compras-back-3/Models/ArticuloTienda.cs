using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace compras_back_3.Models
{
    public class ArticuloTienda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ArticuloId { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulo? Articulo { get; set; }

        public int TiendaId { get; set; }

        [ForeignKey("TiendaId")]
        public virtual Tienda? Tienda { get; set; }

        public DateTime Fecha { get; set; }
    }

}
