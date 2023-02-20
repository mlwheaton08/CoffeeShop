using CoffeeShop.Repositories;
using System.Drawing;

namespace CoffeeShop.Models;

public class Coffee
{
    private readonly BeanVarietyRepository _beanVarietyRepository = new BeanVarietyRepository();

    public int Id { get; set; }
    public string Style { get; set; }
    public int BeanVarietyId { get; set; }
    public BeanVariety BeanVariety { get { return _beanVarietyRepository.Get(BeanVarietyId); } }
    public double Value { get; set; }
}
