using System.ComponentModel.DataAnnotations;

namespace BookAPI.MODELS
{
    public class Pedido
    {
        [Key]
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public int LibroID { get; set; }
        public DateTime FechaPedido { get; set; }

        public Cliente cliente { get; set; }
        public Libro Libro { get; set; }
    }
}
