using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace compras_back_3.Models
{
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticuloId { get; set; }
        public string Código { get; set; }
        public string Descripción { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
    }

}
