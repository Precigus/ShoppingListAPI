using System.Text;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Models;
using ShoppingListApi.Services;

namespace ShoppingListApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingListController : ControllerBase
{
    private static ShoppingListService _shoppingListService = new ShoppingListService();
    private static ItemsGenerator _itemGenerator = new ItemsGenerator();
    
    [HttpPost("basic")]
    public IActionResult Create(ShoppingList shoppingList)
    {
        _shoppingListService.Add(shoppingList);

        return Created("/shoppinglist/basic", shoppingList);
    }
    
    [HttpPost("taxed")]
    public IActionResult Create(TaxedShoppingList shoppingList)
    {
        _shoppingListService.Add(shoppingList);

        return Created("/shoppinglist/taxed", shoppingList);
    }

    [HttpGet("item/random")]
    public IActionResult GetRandomItem()
    {
        var item = _itemGenerator.GenerateItem();

        return Ok(item);
    }

    [HttpGet("total")]
    public IActionResult GetTotalPrice()
    {
        var totalCost = _shoppingListService.CalculateTotalCost();

        return Ok(totalCost);
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var shoppingLists = _shoppingListService.GetAll();
        
        return Ok(shoppingLists);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var shoppingList = _shoppingListService.GetById(id);

        if (shoppingList == null)
        {
            return NotFound($"Shopping list with id {id} was not found");
        }

        return Ok(shoppingList);
    }

    [HttpPatch("{id:int}")]
    public IActionResult AddItem(int id, Item item)
    {
        try
        {
            _shoppingListService.AddItem(id, item);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        return Ok();
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateShoppingList(int id, ShoppingList shoppingList)
    {
        try
        {
            _shoppingListService.Update(id, shoppingList);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
        return Ok();
    }
    
    [HttpPatch("{id:int}/updateName")]
    public IActionResult UpdateShoppingListName(int id, ShoppingList shoppingList)
    {
        try
        {
            _shoppingListService.UpdateName(id, shoppingList.ShopName);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteShoppingList(int id)
    {
        try
        {
            _shoppingListService.Remove(id);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        return Ok();
    }

   
}