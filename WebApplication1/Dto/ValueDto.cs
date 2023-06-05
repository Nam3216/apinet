using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Dto//esto es para validaciones

{
    public class ValueDto
    {
        public int id { get; set; }

        [Required] 
        public string name { get; set; }
     
        public string description { get; set; }

        public int price { get; set; }

        public int quantity { get; set; }

        public string img { get; set; }
    }
}
