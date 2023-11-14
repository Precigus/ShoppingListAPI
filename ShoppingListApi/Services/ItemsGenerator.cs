using System.Text;
using ShoppingListApi.Models;

namespace ShoppingListApi.Services;

public class ItemsGenerator
{
    private static Random _random = new Random();
    
    public Item GenerateItem()
    {
        var bytes = new byte[100];
        _random.NextBytes(bytes);
        var randomName = Encoding.Default.GetString(bytes);

        var item = new Item()
        {
            Amount = _random.NextDouble() * 100,
            Price = (decimal) (_random.NextDouble() * 100),
            Name = randomName
        };

        return item;
    }
}