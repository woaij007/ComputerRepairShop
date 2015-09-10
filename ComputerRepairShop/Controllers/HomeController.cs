using ComputerRepairShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRepairShop.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    [Authorize]
    public ActionResult Order()
    {
      ViewBag.Message = "Customer order page.";

      return View();
    }

    [Authorize(Roles = "admin,employee")]
    public ActionResult AllOrder()
    {
      ViewBag.Message = "Employee order page.";

      return View();
    }

    [Authorize(Roles = "admin,employee")]
    public ActionResult Manage()
    {
      ViewBag.Message = "Emplyee manage page.";

      return View();
    }

    [Authorize(Roles = "admin")]
    public ActionResult Admin()
    {
      string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "admin", });
      ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

      return View();
    }

    [Authorize(Roles = "admin,employee")]
    public ActionResult Comment()
    {
      string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "comment", });
      ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

      return View();
    }

    public ActionResult Class(Models.Classes cs)
    {
      return View(cs.classes);
    }

    public ActionResult _AreaPickup()
    {
      AreaModel am = new AreaModel();
      am.Zipcode = "13210";
      return View(am);
    }

    [Authorize]
    public ActionResult Support()
    {
      return View();
    }
  }
}