using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BeanandBrewV2.Models;

namespace BeanandBrewV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BeanandBrewV2.Models.Coffee> Coffee { get; set; } = default!;
        public DbSet<BeanandBrewV2.Models.CoffeeOrder> CoffeeOrder { get; set; } = default!;
    }
}