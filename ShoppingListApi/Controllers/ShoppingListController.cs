using System.Text;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Models;
using ShoppingListApi.Services;

namespace ShoppingListApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingListController : ControllerBase
{
    private readonly ITaxedShoppingListConverter _shoppingListConverter;
    private readonly IShoppingListService _shoppingListService;
    private readonly IItemsGenerator _itemsGenerator;

    public ShoppingListController(
        IShoppingListService shoppingListService,
        IItemsGenerator itemsGenerator, 
        ITaxedShoppingListConverter shoppingListConverter)
    {
        _shoppingListService = shoppingListService;
        _itemsGenerator = itemsGenerator;
        _shoppingListConverter = shoppingListConverter;
    }
    
    [HttpPost("basic")]
    public IActionResult Create(ShoppingList shoppingList)
    {
        _shoppingListService.Add(shoppingList);

        return Created("/shoppinglist/basic", shoppingList);
    }
    
    [HttpPost("taxed")]
    public IActionResult CreateTaxed(ShoppingList shoppingList)
    {
        var taxedShoppingList = _shoppingListConverter.ConvertToTaxed(shoppingList); 
        _shoppingListService.Add(taxedShoppingList);

        return Created("/shoppinglist/taxed", taxedShoppingList);
    }

    [HttpGet("item/random")]
    public IActionResult GetRandomItem()
    {
        var item = _itemsGenerator.Generate();

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
    
    [HttpGet("name/{name}")]
    public IActionResult GetByName(string name)
    {
        var shoppingList = _shoppingListService.GetByName(name);

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