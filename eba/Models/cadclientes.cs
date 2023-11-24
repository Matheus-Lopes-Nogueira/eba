using System.ComponentModel.DataAnnotations;

namespace eba.Models
{
    public class cadclientes
    {
        [Key]

        public int idcliente { get; set; }
        public string nomecliente { get; set; }
        public string idade { get; set; }
        public string cpf { get; set; }
    }
}
