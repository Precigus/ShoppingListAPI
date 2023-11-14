using ShoppingListApi.Models;

namespace ShoppingListApi.Services;

public interface IItemsGenerator
{
    Item Generate();
}