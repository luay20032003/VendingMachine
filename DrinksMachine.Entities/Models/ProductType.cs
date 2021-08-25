using System.ComponentModel.DataAnnotations;

namespace DrinksMachine.Entities.Models
{
    public class ProductType
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; }
    }
}
