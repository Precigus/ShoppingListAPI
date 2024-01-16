using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Mappers;
using Db = ShoppingListApi.Db;
using Domain = ShoppingListApi.Models;

namespace ShoppingListApi.Repositories;

public class ShoppingListRepository : IShoppingListRepository
{
    private Db.ShoppingContext _context;

    public ShoppingListRepository(Db.ShoppingContext context)
    {
        _context = context;
    }

    public IEnumerable<Domain.ShoppingList?> GetAll()
    {
        return _context.ShoppingLists
            .Include(sl => sl.Items)
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
        return _context.ShoppingLists
            .Include(sl => sl.Items)
            .FirstOrDefault(sl => sl.Id == id)
            .Map();
    }

    public void Add(Domain.ShoppingList shoppingList)
    {
        var dbShoppingList = shoppingList.Map();
        _context.Add(dbShoppingList);
        _context.SaveChanges();
    }

    public void Update(int id, Domain.ShoppingList shoppingList)
    {
        var dbShoppingList = _context.ShoppingLists.Find(id);
        if (dbShoppingList == null) return;
        
    }

    public void Update(int id, string newName)
    {
        var shoppingList = _context.ShoppingLists.Find(id);
        if (shoppingList == null) return;
        shoppingList.ShopName = newName;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var dbShoppingList = new Db.ShoppingList { Id = id };
        _context.Remove(dbShoppingList);
        _context.SaveChanges();
    }
    
}