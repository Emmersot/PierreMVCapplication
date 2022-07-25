using System.Collections.Generic;

namespace Pierre.Models
{
  public class Order
  {
    public string Name { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order> {};  
    public Order(string orderName)
    {
      Name = orderName;
      _instances.Add(this);
      Id = _instances.Count;
    }
    public static List<order> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Order Find(int searchId)
    {
      return _instances[searchId-1];
    }  
  }
}