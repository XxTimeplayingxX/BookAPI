using System.ComponentModel.DataAnnotations;

namespace BookAPI.MODELS
{
    public class GeneroDetalle
    {
        [Key]
        public int ID { get; set; }
        public int GeneroID { get; set; }
        public Genero Genero { get; set; }
    }
}
