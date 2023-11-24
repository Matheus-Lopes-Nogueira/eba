using System.ComponentModel.DataAnnotations;

namespace eba.Models
{
    public class inventariomodel
    {
        [Key]

        public int idinventario { get; set; }
        public int idcliente { get; set; }
        public int idmaquina { get; set; }
        public int qtvalor { get; set; }

        public List<cadclientes>listacli { get; set;  }
        public List<cadmaquinas> listamaq { get; set; }
    }
}
