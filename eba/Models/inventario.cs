using System.ComponentModel.DataAnnotations;

namespace eba.Models
{
    public class inventario
    {
        [Key]

        public int idinventario { get; set; }
        public int idcliente { get; set; }
        public int idmaquina { get; set; }
        public int qtvalor { get; set; }
    }
}
