using System.Collections.Generic;

namespace Pierre.Models
{
  public class Vender
  {
    private static List<Vender> _instances = new List<Vender> {};
    public string Name { get; set; }
    public int Id { get; }
    public List<Order> Orders { get; set; }

    public Vender(string venderName)
    {
      Name = venderName;
      _instances.Add(this);
      Id = _instances.Count;
      Orders = new List<Order>{};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Vender> GetAll()
    {
      return _instances;
    }

    public static Vender Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }
  }
}