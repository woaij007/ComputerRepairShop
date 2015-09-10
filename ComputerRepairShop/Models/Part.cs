using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerRepairShop.Models
{

  using System.ComponentModel.DataAnnotations;
  public class Part
  {
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
  }
}