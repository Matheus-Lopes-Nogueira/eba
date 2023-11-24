using System.ComponentModel.DataAnnotations;

namespace eba.Models
{
    public class cadmaquinas
    {
        [Key]
        
        public int idmaquina { get; set; }
        public string nomemaquina { get; set; }
        public string patrimonio { get; set; }
        public int memoria { get; set; }
        public int hd { get; set; }
    }
}
