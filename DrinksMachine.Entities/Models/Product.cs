using System.ComponentModel.DataAnnotations;

namespace DrinksMachine.Entities.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Product Type")]
        public int ProductTypeID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Product Name is longer than {1} characters")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public int ProductPrice { get; set; }
        [Required]
        [Display(Name = "Qty In Stock")]
        public int QuantityInStock { get; set; }


    }
}
