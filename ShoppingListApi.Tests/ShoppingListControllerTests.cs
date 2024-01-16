using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Controllers;
using ShoppingListApi.Models;
using ShoppingListApi.Services;

namespace ShoppingListApi.Tests;

public class ShoppingListControllerTests
{
    private readonly ShoppingListController _controller;
    
    private readonly ITaxedShoppingListConverter _shoppingListConverter;
    private readonly IShoppingListService _shoppingListService;
    private readonly IItemsGenerator _itemsGenerator;

    public ShoppingListControllerTests()
    {
        _shoppingListConverter = new TaxedShoppingListConverter(new ITaxPolicy[] { new FixedTaxPolicy(1)});
        _shoppingListService = new ShoppingListService(null, null);
        _itemsGenerator = new ItemsGenerator();

        _controller = new ShoppingListController(_shoppingListService, _itemsGenerator, _shoppingListConverter);
    }
    
    [Fact]
    public void Get_WhenShoppingListDoesNotExist_ReturnsNotFound()
    {
        const int nonExistingShoppingListId = 0;

        var response = _controller.GetById(nonExistingShoppingListId);

        Assert.IsAssignableFrom<NotFoundObjectResult>(response);
    }
    
    [Fact]
    public void Get_WhenShoppingListExists_ReturnsOk()
    {
        const int existingShoppingListId = 0;
        var addedShoppingList = new ShoppingList() { Id = existingShoppingListId };
        _shoppingListService.Add(addedShoppingList);

        var response = _controller.GetById(existingShoppingListId);
        Assert.IsAssignableFrom<OkObjectResult>(response);
    }

    [Fact]
    public void GetByName_WhenNonExistingShoppingList_ReturnsOk()
    {
        const string nonExistingShoppingListName = "AbsentList";

        var response = _controller.GetByName(nonExistingShoppingListName);

        Assert.IsAssignableFrom<OkObjectResult>(response);
    }
    [Theory]
    [InlineData("Existing")]
    [InlineData("existing")]
    [InlineData("eXisting")]
    public void GetByName_WhenExistingShoppingList_ReturnsOk(string shopName)
    {
        const string existingShoppingListName = "ExistingList";

        _shoppingListService.Add(new ShoppingList() { ShopName = existingShoppingListName});

        var response = _controller.GetByName(existingShoppingListName);

        Assert.IsAssignableFrom<OkObjectResult>(response);
    }
}