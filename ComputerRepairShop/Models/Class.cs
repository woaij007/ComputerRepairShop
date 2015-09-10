using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace ComputerRepairShop.Models
{
  public class Class
  { 
    public int Id { get; set; }
    public string Title { get; set; }
    public string Time { get; set; }
    public string Place { get; set; }
    public string Description { get; set; }

  }

  public class Classes
  {
    string path;

    public List<Class> classes { get; set; }

    public Classes()
    {
      classes = new List<Class>();
      path = HttpContext.Current.Server.MapPath("~\\App_Data\\Classes.xml");
      Fill();
    }

    public void Fill()
    {
        XDocument doc = XDocument.Load(path);

        var q = from cls in doc.Elements("classes").Elements("class") select cls;
        int i = 0;
        foreach (var elem in q)
        {
          Class c = new Class();
          c.Id = ++i;
          c.Title = elem.Element("title").Value;
          c.Time = elem.Element("time").Value;
          c.Place = elem.Element("place").Value;
          c.Description = elem.Element("description").Value;
          classes.Add(c);
        }
      return;
    }
  }
}
