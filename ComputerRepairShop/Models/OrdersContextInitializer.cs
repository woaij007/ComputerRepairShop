using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerRepairShop.Models
{
  using System.Data.Entity;

  public class OrdersContextInitializer : DropCreateDatabaseIfModelChanges<OrdersContext>
  {
    protected override void Seed(OrdersContext context)
    {
      var parts = new List<Part>()            
            {
                new Part() { Name = "Screen", Price = 49.99M, Amount = 10, Description = "Computer Screen" },
                new Part() { Name = "Memory", Price = 99.99M, Amount = 10, Description = "Computer Memory" },
                new Part() { Name = "Keyboard", Price = 19.99M, Amount = 10, Description = "Computer Keyboard" }
            };

      parts.ForEach(p => context.Parts.Add(p));
      context.SaveChanges();

      var order = new Order() { Customer = "Woaij007" };
      var od = new List<OrderDetail>()
            {
                new OrderDetail() { Part = parts[0], Quantity = 2, Order = order},
                new OrderDetail() { Part = parts[1], Quantity = 4, Order = order}
            };
      context.Orders.Add(order);
      od.ForEach(o => context.OrderDetails.Add(o));

      context.SaveChanges();
    }
  }
}