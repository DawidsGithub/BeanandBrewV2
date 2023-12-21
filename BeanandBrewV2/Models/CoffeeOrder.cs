using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanandBrewV2.Models
{
    public class CoffeeOrder
    {

            [Key]
            public int OrderId { get; set; }
            public int CoffeeId { get; set; }
            public string? CoffeeName { get; set; }
            public int CoffeeAmount { get; set; }

            [ForeignKey("ApplicationUser")]

            public string? UserId { get; set; }

            public virtual ApplicationUser? User { get; set; }
        }
    }