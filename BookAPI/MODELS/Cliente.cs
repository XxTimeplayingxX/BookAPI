using System.ComponentModel.DataAnnotations;

namespace BookAPI.MODELS
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        public string NombreCompleto { get; set; }
        public string email { get; set; }
    }
}
