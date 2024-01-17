using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Models;

namespace ShoppingListApi.Db;

public class ShoppingContext : DbContext
{
    public DbSet<ShoppingList?> ShoppingLists { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .HasKey(i => i.Id);

        modelBuilder.Entity<ShoppingList>()
            .HasKey(sl => sl.Id);
    }
    
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