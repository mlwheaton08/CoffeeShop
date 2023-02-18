using CoffeeShop.Models;

namespace CoffeeShop.Repositories;

public class BeanVarietyRepository : IBeanVarietyRepository
{
    private static List<BeanVariety> _beanVarieties = new List<BeanVariety>()
    {
        new BeanVariety() {Id = 1, Name = "Arusha", Region = "Mount Meru in Tanzania, and Papua New Guinea", Notes = null},
        new BeanVariety() {Id = 2, Name = "Benguet", Region = "Philippines", Notes = "Typica variety grown in Benguet in the Cordillera highlands of the northern Philippines since 1875."},
        new BeanVariety() {Id = 3, Name = "Catuai", Region = "Latin America", Notes = "This is a hybrid of Mundo Novo and Caturra bred in Brazil in the late 1940s."},
        new BeanVariety() {Id = 4, Name = "Typica", Region = "Worldwide", Notes = " 	Typica originated from Yemeni stock, taken first to Malabar, India, and later to Indonesia by the Dutch, and the Philippines by the Spanish"},
        new BeanVariety() {Id = 5, Name = "Ruiru 11", Region = "Kenya", Notes = "Ruiru 11 was released in 1985 by the Kenyan Coffee Research Station. While the variety is generally disease resistant, it produces a lower cup quality than K7, SL28 and 34"}
    };

    public List<BeanVariety> GetAll()
    {
        return _beanVarieties;
    }

    public BeanVariety Get(int id)
    {
        return _beanVarieties.Find(b => b.Id == id);
    }

    public void Add(BeanVariety variety)
    {
        _beanVarieties.Add(variety);
    }

    public void Update(BeanVariety variety)
    {
        var foundBeanVariety = _beanVarieties.Find(b => b.Id == variety.Id);

        foundBeanVariety = variety;
    }

    public void Delete(int id)
    {
        _beanVarieties.Remove(Get(id));
    }
}