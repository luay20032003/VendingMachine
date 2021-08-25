using System.ComponentModel.DataAnnotations;

namespace DrinksMachine.Entities.Models
{
    public class Currency
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Currency Name is longer than {1} characters")]
        [Display(Name = "Currency Name")]
        public string CurrencyName { get; set; }
        [Required]
        [Display(Name = "Currency Value")]
        public decimal CurrencyValue { get; set; }
        [Required]
        [Display(Name = "Qty In Hand")]
        public int QuantityInHand { get; set; }
    }
}
