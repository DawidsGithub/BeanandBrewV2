using System.ComponentModel.DataAnnotations;

namespace BeanandBrewV2.Models
{
    public class CoffeeOrder
    {

            [Key]
            public int OrderId { get; set; }
            public int CoffeeId { get; set; }
            public string? CoffeeName { get; set; }
            public int CoffeeAmount { get; set; }
        }
    }