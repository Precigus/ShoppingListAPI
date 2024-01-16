using ShoppingListApi.Models;

namespace ShoppingListApi.Repositories;

public interface IShoppingListRepository
{
    IEnumerable<ShoppingList?> GetAll();
    IEnumerable<ShoppingList?> GetByName(string name);
    ShoppingList? GetById(int id);
    void Add(ShoppingList shoppingList);
    void Update(int id, ShoppingList shoppingList);
    void Update(int id, string newName);
    void Delete(int id);
}