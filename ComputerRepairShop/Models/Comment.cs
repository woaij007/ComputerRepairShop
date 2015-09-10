using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerRepairShop.Models
{
  using System.ComponentModel.DataAnnotations;
  public class Comment
  {
    [ScaffoldColumn(false)]
    public int Id {get; set;}
    [Required]
    public string Question { get; set; }
    public string Answer { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
  }
}