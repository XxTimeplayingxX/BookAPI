using System.ComponentModel.DataAnnotations;

namespace BookAPI.MODELS
{
    public class Genero
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public int LibroID { get; set; }
        public Libro Libro { get; set; }

    }
}
