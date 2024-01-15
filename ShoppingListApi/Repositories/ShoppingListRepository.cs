using System.Runtime.ExceptionServices;
using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Mappers;
using Db = ShoppingListApi.Db;
using Domain = ShoppingListApi.Models;

namespace ShoppingListApi.Repositories;

public class ShoppingListRepository
{
    private Db.ShoppingContext _context;

    public ShoppingListRepository(Db.ShoppingContext context)
    {
        _context = context;
    }

    public IEnumerable<Domain.ShoppingList?> GetAll()
    {
        return _context.ShoppingLists
            .ToList()
            .Select(sl => sl.Map());
    }
    
    // GetByName
    public IEnumerable<Domain.ShoppingList?> GetByName(string name)
    {
        return _context
            .ShoppingLists
            .Include(sl => sl.Items)
            .Where(sl => sl.ShopName == name)
            .Select(sl => sl.Map());
    }

    public Domain.ShoppingList GetById(int id)
    {
        return _context
            .ShoppingLists
            .FirstOrDefault(sl => sl.Id == id)
            .Map();
    }

    public void Create(Domain.ShoppingList shoppingList)
    {
        var dbShoppingList = shoppingList.Map();
        _context.Add(dbShoppingList);
        _context.SaveChanges();
    }

    public void UpdateShoppingList(int id, Domain.ShoppingList shoppingList)
    {
        
    }

    public void UpdateShoppingListName(int id, string newName)
    {
        
    }

    public void DeleteShoppingList(int id)
    {
        
    }
    
}