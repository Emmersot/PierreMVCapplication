using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;

namespace Pierre.Controllers
{
  public class OrderController : Controller
  {

    [HttpGet("/venders/{venderId}/orders/new")]
    public ActionResult New(int venderId)
    {
      Vender vender = Vender.Find(venderId);
      return View(vender);
    }

    [HttpPost("/orders/delete")]
    public ActionResult DeleteAll()
    {
      Order.ClearAll();
      return View();
    }

    [HttpGet("/venders/{venderId}/orders/{orderId}")]
    public ActionResult Show(int venderId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vender vender = Vender.Find(venderId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vender", vender);
      return View(model);
    }
  }
}