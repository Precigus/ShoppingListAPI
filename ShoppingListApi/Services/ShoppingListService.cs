using ShoppingListApi.Models;
using ShoppingListApi.Repositories;

namespace ShoppingListApi.Services;

public class ShoppingListService : IShoppingListService
{

    private readonly IShoppingListRepository _shoppingListRepository;
    private readonly IItemsRepository _itemsRepository;

    public ShoppingListService(IShoppingListRepository shoppingListRepository, IItemsRepository itemsRepository)
    {
        _shoppingListRepository = shoppingListRepository;
        _itemsRepository = itemsRepository;
    }

    public decimal CalculateTotalCost()
    {
        return _shoppingListRepository
            .GetAll()
            .Select(sl => sl.CalculateTotalCost())
            .Sum();
    }

    public void Add(ShoppingList shoppingList)
    {
        _shoppingListRepository.Add(shoppingList);
    }
    
    public IEnumerable<ShoppingList?> GetAll()
    {
        return _shoppingListRepository.GetAll();
    }
    
    public ShoppingList? GetById(int id)
    {
        return _shoppingListRepository.GetById(id);
    }

    public IEnumerable<ShoppingList?> GetByName(string name)
    {
        return _shoppingListRepository.GetByName(name);
    }
    
    public void Remove(int id)
    {
        _shoppingListRepository.Delete(id);
    }

    public void UpdateName(int id, string newName)
    {
        _shoppingListRepository.Update(id, newName);
    }

    public void Update(int id, ShoppingList update)
    {
        _shoppingListRepository.Update(id, update);
    }

    public void AddItem(int id, Item item)
    {
        _itemsRepository.Create(id, item);
    }
}