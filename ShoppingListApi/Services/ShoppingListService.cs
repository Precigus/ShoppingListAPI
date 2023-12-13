using ShoppingListApi.Models;

namespace ShoppingListApi.Services;

public class ShoppingListService : IShoppingListService
{
    private Dictionary<int, ShoppingList> _shoppingLists = new Dictionary<int, ShoppingList>();

    public decimal CalculateTotalCost()
    {
        return _shoppingLists.Values
            .Select(sl => sl.CalculateTotalCost())
            .Sum();
    }

    public void Add(ShoppingList shoppingList)
    {
        _shoppingLists.Add(shoppingList.Id, shoppingList);
    }
    
    public IEnumerable<ShoppingList> GetAll()
    {
        return _shoppingLists.Values;
    }
    
    public ShoppingList? GetById(int id)
    {
        if (_shoppingLists.TryGetValue(id, out var shoppingList))
        {
            return shoppingList;
        }

        return null;
    }

    public IEnumerable<ShoppingList> GetByName(string name)
    {
        return _shoppingLists.Values
            .Where(sl =>
                sl.ShopName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
    }
    
    public void Remove(int id)
    {
        var shoppingList = GetById(id);
        if (shoppingList == null) throw new ArgumentException($"Shopping list with id {id} was not found");
        
        _shoppingLists.Remove(shoppingList.Id);
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