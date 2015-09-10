using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRepairShop.Models
{
  public class AreaModel
  {
    public string Zipcode { get; set; }
    public IEnumerable<SelectListItem> ZipcodeList
    {
      get
      {
        List<SelectListItem> list = new List<SelectListItem> { 
          new SelectListItem() { Text = "13210", Value = "same area" }, 
          new SelectListItem() { Text = "13244", Value = "same area" }, 
          new SelectListItem() { Text = "13202", Value = "adjacent area" },
          new SelectListItem() { Text = "13203", Value = "adjacent area" },
          new SelectListItem() { Text = "13205", Value = "adjacent area" },
          new SelectListItem() { Text = "13206", Value = "adjacent area" },
          new SelectListItem() { Text = "13224", Value = "adjacent area" },
          new SelectListItem() { Text = "13278", Value = "adjacent area" },
          new SelectListItem() { Text = "other", Value = "UPS reachable area" },};
        return list.Select(l => new SelectListItem { Selected = (l.Value == Zipcode), Text = l.Text, Value = l.Value });
      }
    }
  }
}