using Db = ShoppingListApi.Db;
using Domain = ShoppingListApi.Models;

namespace ShoppingListApi.Mappers;

public static class ItemMapper
{
    public static Domain.Item Map(this Db.Item item)
    {
        return new Domain.Item
        {
            Name = item.Name,
            Amount = item.Amount,
            Price = item.Price
        };
    }
    
    public static Db.Item Map(this Domain.Item item)
    {
        return new Db.Item
        {
            Name = item.Name,
            Amount = item.Amount,
            Price = item.Price
        };
    }
}