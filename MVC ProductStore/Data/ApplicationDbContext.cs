using Microsoft.EntityFrameworkCore;
using MVC_ProductStore.Models.Entities;
using MVC_ProductStore.Models.ViewModel;

namespace MVC_ProductStore.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().ToTable("Product");
        modelBuilder.Entity<Category>().ToTable("Category");
        modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");

        //MANUFACTURER
        modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
        {
            ManufacturerId = 1,
            Address = "Lodve Langesgate 2, 8514 Narvik",
            Name = "UiT Norges arktiske universitet i Narvik"
        });
        modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
        {
            ManufacturerId = 2,
            Address = "Hawthorne, California, USA",
            Name = "SpaceX"
        });

        //CATEGORY
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 1,
            Name = "Verktøy"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 2,
            Name = "Kjøretøy"
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 3,
            Name = "Dagligvarer"
        });

        //PRODUCT
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 1,
            Name = "Hammer",
            Price = 121.50m,
            CategoryId = 1,
            ManufacturerId = 1
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 2,
            Name = "Vinkelsliper",
            Price = 1520.00m,
            CategoryId = 1,
            ManufacturerId = 1
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 3,
            Name = "Volvo XC90",
            Price = 990000m,
            CategoryId = 2,
            ManufacturerId = 1
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 4,
            Name = "Volvo XC60",
            Price = 620000m,
            CategoryId = 2,
            ManufacturerId = 1
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            ProductId = 5,
            Name = "Brød",
            Price = 25.50m,
            CategoryId = 3,
            ManufacturerId = 2
        });
    }
    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Manufacturer> Manufacturer { get; set; }
}


