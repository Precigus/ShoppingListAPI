using ShoppingListApi.Models;

namespace ShoppingListApi.Db;

public class Item
{
    public int It { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public double Amount { get; set; }
    public virtual ShoppingList ShoppingList { get; set; }
    public int ShoppingListId { get; set; }
}