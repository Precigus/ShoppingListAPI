using ShoppingListApi.Models;

namespace ShoppingListApi.Services;

public interface IShoppingListService
{
    decimal CalculateTotalCost();
    void Add(ShoppingList shoppingList);
    IEnumerable<ShoppingList> GetAll();
    ShoppingList? GetById(int id);
    IEnumerable<ShoppingList> GetByName(string name);
    void Remove(int id);
    void UpdateName(int id, string newName);
    void Update(int id, ShoppingList shoppingList);
    void AddItem(int id, Item item);
}