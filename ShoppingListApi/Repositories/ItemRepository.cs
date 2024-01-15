using ShoppingListApi.Db;

namespace ShoppingListApi.Repositories;

public class ItemRepository
{
    private ShoppingContext _context;

    public ItemRepository(ShoppingContext context)
    {
        _context = context;
    }

    public void AddItem(int shoppingListId, Item item)
    {
        
    }
}