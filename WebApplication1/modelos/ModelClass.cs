using System.ComponentModel.DataAnnotations;


namespace WebApplication1.modelos
{
    public class ModelClass
    {
        [Key]
        public int id { get; set; }
        
       [Required]
        public string name { get; set; }

        public string description { get; set; }

        public int price { get; set; }

        public int quantity { get; set; }

        public string img { get; set; }
    }
}
