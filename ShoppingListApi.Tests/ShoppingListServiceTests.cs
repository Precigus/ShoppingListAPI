using ShoppingListApi.Models;
using ShoppingListApi.Repositories;
using ShoppingListApi.Services;

namespace ShoppingListApi.Tests;

public class ShoppingListServiceTests : DbTests
{
    private readonly ShoppingListRepository _shoppingListRepositoryepository;
    private readonly ItemsRepository _itemsRepository;

    public ShoppingListServiceTests()
    {
        _shoppingListRepositoryepository = new ShoppingListRepository(Context);
        _itemsRepository = new ItemsRepository(Context);
    }

    [Fact]
    public void Remove_WhenNonExistingShoppingListId_ThrowsArgumentException()
    {
        const int nonExistingShoppingListId = 0;
        var service = new ShoppingListService(_shoppingListRepositoryepository, _itemsRepository);
        Action removeNonExistingShoppingList = () => service.Remove(nonExistingShoppingListId);

        // Verify an exception was thrown
        Assert.Throws<ArgumentNullException>(removeNonExistingShoppingList);
    }
    
    [Fact]
    public void Remove_WhenShopiingListsExists_RemoveIt()
    {
        const int existingShoppingListId = 1;
        var service = new ShoppingListService(_shoppingListRepositoryepository, _itemsRepository);
        var removedShoppingList = new ShoppingList() { Id = existingShoppingListId, ShopName="NotNull", Address = "NotNull"};
        service.Add(removedShoppingList);
        
        service.Remove(existingShoppingListId);

        var shoppingLists = service.GetAll();
        Assert.DoesNotContain(removedShoppingList, shoppingLists);
    }
}