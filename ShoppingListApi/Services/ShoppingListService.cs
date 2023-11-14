using ShoppingListApi.Models;

namespace ShoppingListApi.Services;

public class ShoppingListService
{
    private List<ShoppingList> _shoppingLists = new List<ShoppingList>();

    public decimal CalculateTotalCost()
    {
        decimal totalTotalCost = 0;
        foreach (var shoppingList in _shoppingLists)
        {
            totalTotalCost = shoppingList.CalculateTotalCost();
        }

        return totalTotalCost;
    }

    public void Add(ShoppingList shoppingList)
    {
        _shoppingLists.Add(shoppingList);
    }
    
    public List<ShoppingList> GetAll()
    {
        return _shoppingLists;
    }
    
    public ShoppingList? GetById(int id)
    {
        foreach (var list in _shoppingLists)
        {
            if (list.Id == id)
            {
                return list;
            }
        }

        return null;
    }
    
    public void Remove(int id)
    {
        var shoppingList = GetById(id);
        if (shoppingList == null) throw new ArgumentException($"Shopping list with id {id} was not found");
        
        _shoppingLists.Remove(shoppingList);
    }

    public void UpdateName(int id, string newName)
    {
        if (newName == null) throw new ArgumentException("Please provide a name for for update");
        
        var oldShoppingList = GetById(id);

        if (oldShoppingList == null) throw new ArgumentException($"Shopping list with id {id} was not found");
        
        oldShoppingList.ShopName = newName;
    }

    public void Update(int id, ShoppingList update)
    {
        var oldShoppingList = GetById(id);

        if (oldShoppingList == null) throw new ArgumentException($"Shopping list with id {id} was not found");
        
        oldShoppingList.Update(update);
    }

    public void AddItem(int id, Item item)
    {
        var shoppingList = GetById(id);
        
        if (shoppingList == null) throw new ArgumentException($"Shopping list with id {id} was not found");
        
        shoppingList.AddItem(item);
    }
}