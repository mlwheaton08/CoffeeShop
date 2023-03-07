using CoffeeShop.Repositories;
using System.Drawing;

namespace CoffeeShop.Models;

public class Coffee
{
    public int Id { get; set; }
    public string Style { get; set; }
    public int BeanVarietyId { get; set; }
    public BeanVariety BeanVariety { get; set; }
}