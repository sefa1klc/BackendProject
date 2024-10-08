using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class NorthwindContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // to inform us which database we are using
        optionsBuilder.UseSqlServer(
            @"Server=localhost;
                          Database=FinalProject;
                          Trusted_Connection=True;
                          TrustServerCertificate=True;");


    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}