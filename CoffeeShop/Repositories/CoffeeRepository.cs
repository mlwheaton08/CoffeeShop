using CoffeeShop.Models;

namespace CoffeeShop.Repositories;

public class CoffeeRepository : ICoffeeRepository
{
    private static List<Coffee> _coffees = new List<Coffee>()
    {
        new Coffee() {Id = 1, Style = "Drip Brew", BeanVarietyId = 1, Value = 2},
        new Coffee() {Id = 2, Style = "Drip Brew", BeanVarietyId = 2, Value = 2.3},
        new Coffee() {Id = 3, Style = "Pour Over", BeanVarietyId = 2, Value = 2.1},
        new Coffee() {Id = 4, Style = "Drip Brew", BeanVarietyId = 3, Value = 2.3},
        new Coffee() {Id = 5, Style = "Drip Brew", BeanVarietyId = 4, Value = 2.5},
        new Coffee() {Id = 6, Style = "Cold Brew", BeanVarietyId = 4, Value = 3},
        new Coffee() {Id = 7, Style = "Espresso", BeanVarietyId = 4, Value = 2.7},
        new Coffee() {Id = 8, Style = "Drip Brew", BeanVarietyId = 5, Value = 3.5},
        new Coffee() {Id = 9, Style = "Espresso", BeanVarietyId = 5, Value = 3}
    };

    public List<Coffee> GetAll()
    {
        return _coffees;
    }

    public Coffee Get(int id)
    {
        return _coffees.Find(c => c.Id == id);
    }

    public void Add(Coffee coffee)
    {
        _coffees.Add(coffee);
    }

    public void Update(Coffee coffee)
    {
        var foundCoffee = _coffees.Find(c => c.Id == coffee.Id);

        foundCoffee = coffee;
    }

    public void Delete(int id)
    {
        _coffees.Remove(Get(id));
    }
}
