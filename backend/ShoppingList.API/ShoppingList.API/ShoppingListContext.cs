using Microsoft.EntityFrameworkCore;

namespace ShoppingList.API;

public class ShoppingListContext : DbContext
{
    public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options)
    {
    }

    public DbSet<ShoppingItem> ShoppingItems { get; set; }
}