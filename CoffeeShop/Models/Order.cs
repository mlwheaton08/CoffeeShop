//using System.Drawing;

//namespace CoffeeShop.Models;

//public class Order
//{
//    private Dictionary<string, double> _sizesValue = new Dictionary<string, double>()
//    {
//        { "Small", 1 },
//        { "Medium", 1.7 },
//        { "Large", 2.3 }
//    };

//    public int Id { get; set; }
//    public string CustomerName { get; set; }
//    public Coffee Coffee { get; set; }
//    public string Size { get; set; }
//    public string Notes { get; set; }
//    public double Price
//    {
//        get
//        {
//            double sizePrice = _sizesValue.FirstOrDefault(x => x.Key == Size).Value;
//            return sizePrice * Coffee.Value;
//        }
//    }
//    public bool Completed { get; set; } = false;
//}