using System.ComponentModel.DataAnnotations;

namespace BeanandBrewV2.Models
{
    public class Coffee
    {

        [Display(Name = "Coffee ID")]
        public int CoffeeId { get; set; }

        [Display(Name = "Coffee Name")]
        public string? CoffeeName { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Coffee Price")]
        public float CoffeePrice { get; set; }

        [Display(Name = "Coffee Size")]
        public int CoffeeSize { get; set; }

        [Display(Name = "File Name")]
        public string? ImagePath { get; set; }

        public ICollection<CoffeeOrder>? CoffeeOrders { get; set; }
    }
}
