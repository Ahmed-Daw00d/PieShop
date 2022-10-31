using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DawoodShopNew.Models
{
    public class DawoodShopNewDbContext : IdentityDbContext
    {
        public DawoodShopNewDbContext(DbContextOptions<DawoodShopNewDbContext> option) : base(option)
        {
        }

       
      public  DbSet<Category> Categories { get; set; }
       public DbSet<Pie>Pies { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
