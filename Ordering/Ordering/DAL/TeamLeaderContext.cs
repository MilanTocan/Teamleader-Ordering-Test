using System.Data.Entity;
using Ordering.Models;

namespace Ordering.DAL
{
    public class TeamLeaderContext : DbContext
    {
        public TeamLeaderContext(): base("TeamleaderOrdering")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
