using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerRepairShop.Models
{
  public class OrderDTO
  {
    public class Detail
    {
      public int PartID { get; set; }
      public string Part { get; set; }
      public decimal Price { get; set; }
      public int Quantity { get; set; }
    }
    public IEnumerable<Detail> Details { get; set; }
  }
}