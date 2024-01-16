using ShoppingListApi.Models;

namespace ShoppingListApi.Repositories;

public interface IItemsRepository
{
    void Create(int id, Item item);
}