using ShoppingListApi.Models;
using ShoppingListApi.Services;

namespace ShoppingListApi.Tests;

public class ShoppingListServiceTests
{
    [Fact]
    public void Remove_WhenNonExistingShoppingListId_ThrowsArgumentException()
    {
        const int nonExistingShoppingListId = 0;
        var service = new ShoppingListService();
        Action removeNonExistingShoppingList = () => service.Remove(nonExistingShoppingListId);

        // Varify an exception was thrown
        Assert.Throws<ArgumentException>(removeNonExistingShoppingList);
    }
    
    [Fact]
    public void Remove_WhenShopiingListsExists_RemoveIt()
    {
        const int existingShoppingListId = 1;
        var service = new ShoppingListService();
        var removedShoppingList = new ShoppingList() { Id = existingShoppingListId };
        service.Add(removedShoppingList);
        
        service.Remove(existingShoppingListId);

        var shoppingLists = service.GetAll();
        Assert.DoesNotContain(removedShoppingList, shoppingLists);
    }
}