using System.ComponentModel.DataAnnotations;

namespace BookAPI.MODELS
{
    public class Libro
    {
        [Key]
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime Publicacion { get; set; }
    }
}
