using Microsoft.EntityFrameworkCore;

namespace EMemorandum.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Define your DbSets (tables)
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}
