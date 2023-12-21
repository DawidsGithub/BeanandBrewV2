using Microsoft.AspNetCore.Identity;
namespace BeanandBrewV2.Models
{
    public class ApplicationUser:IdentityUser
    {

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int StaffPermision { get; set; }

        public ICollection<CoffeeOrder> CoffeeOrders { get; } = new List<CoffeeOrder>();

    }
}
