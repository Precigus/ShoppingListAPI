using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Models;

namespace ShoppingListApi.Db;

public class ShoppingContext : DbContext
{
    public DbSet<ShoppingList?> ShoppingLists { get; set; }
    public DbSet<Item> Items { get; set; }

    public ShoppingContext() : base(UseSqlite())
    { }

    public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
    { }

    private static DbContextOptions<ShoppingContext> UseSqlite()
    {
        return new DbContextOptionsBuilder<ShoppingContext>()
            .UseSqlite(@"DataSource=ShoppingList.db")
            .LogTo(m => Debug.WriteLine(m))
            .Options;
    }
}