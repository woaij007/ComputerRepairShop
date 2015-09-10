using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerRepairShop.Models
{
  public class OrderDetail
  {
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public int PartId { get; set; }

    // Navigation properties
    public Part Part { get; set; }
    public Order Order { get; set; }
  }
}