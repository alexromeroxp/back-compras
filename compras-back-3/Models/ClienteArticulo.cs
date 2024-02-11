using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace compras_back_3.Models
{
    public class ClienteArticulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente? Cliente { get; set; }

        public int ArticuloId { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulo? Articulo { get; set; }

        public int Cantidad {get;set;}

        public DateTime Fecha { get; set; }
    }

}
