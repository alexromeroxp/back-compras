using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace compras_back_3.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dirección { get; set; }
    }

}
