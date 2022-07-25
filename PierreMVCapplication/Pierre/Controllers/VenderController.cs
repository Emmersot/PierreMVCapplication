using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Pierre.Models;

namespace Pierre.Controllers
{
  public class VenderController : Controller
  {

    [HttpGet("/venders")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/venders/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/venders")]
    public ActionResult Create(string venderName)
    {
      Vender newVender = new Vender(venderName);
      return RedirectToAction("Index");
    }

    [HttpGet("/venders/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vender selectedVender = Vender.Find(id);
      List<Vender> venderOrders = selectedVender.Orders;
      model.Add("vender", selectedVender);
      model.Add("orders", venderOrders);
      return View(model);
    }


    // This one creates new Items within a given Category, not new Categories:

    [HttpPost("/venders/{venderId}/orders")]
    public ActionResult Create(int venderId, string songName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vender foundVender = Vender.Find(venderId);
      Order newOrder = new Order(orderName);
      foundVender.AddOrder(newOrder);
      List<Order> venderOrders = foundVender.Orders;
      model.Add("orders", venderOrders);
      model.Add("vender", foundVender);
      return View("Show", model);
    }
  }
}