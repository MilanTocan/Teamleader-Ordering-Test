namespace Ordering.Migrations
{
    using Ordering.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ordering.DAL.TeamLeaderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ordering.DAL.TeamLeaderContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Customers.AddOrUpdate(c => c.Name,
                new Customer { ID = 1, Name = "Coca Cola", Since = new DateTime(2014, 6, 28), Revenue = 492.12M },
                new Customer { ID = 2, Name = "Teamleader", Since = new DateTime(2015, 1, 15), Revenue = 1505.95M },
                new Customer { ID = 3, Name = "Jeroen De Wit", Since = new DateTime(2016, 2, 11), Revenue = 0.0M }
            );

            context.Products.AddOrUpdate(p => p.ID,
                new Product { ID = "A101", Description = "Screwdriver", Category = "1", Price = 9.75M },
                new Product { ID = "A102", Description = "Electric Screwdriver", Category = "1", Price = 49.50M },
                new Product { ID = "B101", Description = "Basic on-off switch", Category = "2", Price = 4.99M },
                new Product { ID = "B102", Description = "Press Button", Category = "2", Price = 4.99M },
                new Product { ID = "B103", Description = "Switch with motion detector", Category = "2", Price = 12.95M }
            );

            context.Orders.AddOrUpdate(o => o.ID,
                new Order { ID = 1, CustomerId = 1, Total = 49.90M },
                new Order { ID = 2, CustomerId = 2, Total = 24.95M },
                new Order { ID = 3, CustomerId = 3, Total = 69.00M }
            );

            context.OrderDetails.AddOrUpdate(i => i.ID,
                // Order 1
                new OrderDetail { ID = 1, OrderId = 1, ProductId = "B102", Quantity = 10 },
                // Order 2
                new OrderDetail { ID = 2, OrderId = 2, ProductId = "B102", Quantity = 5 },
                // Order 3
                new OrderDetail { ID = 3, OrderId = 3, ProductId = "A101", Quantity = 2 },
                new OrderDetail { ID = 4, OrderId = 3, ProductId = "A102", Quantity = 1 }
            );
        }
    }
}
