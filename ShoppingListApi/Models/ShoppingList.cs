namespace ShoppingListApi.Models;

public class ShoppingList
{
    public int Id { get; set; }
    public string? ShopName { get; set; }
    public string? Address { get; set; }
    public decimal TotalPrice
    {
        get
        {
            return CalculateTotalCost();
        }
    }
    public IEnumerable<Item> Items
    {
        get
        {
            return _items;
        }
    }
    private List<Item> _items { get; set; } = new List<Item>();

    public virtual decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (var item in Items)
        {
            totalCost += item.Price;
        }

        return totalCost;
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void Update(ShoppingList shoppingList)
    {
        _items = shoppingList.Items.ToList();
        Address = shoppingList.Address;
        ShopName = shoppingList.ShopName;
    }
}