using CakeWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CakeWebsite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category>Categories {get; set;}

        //adding some Category items to the Database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Vanilla Cake", DisplayOrder = 1 },
                new Category { Id=2, Name="Chocolate Cake", DisplayOrder=2},
                new Category { Id= 3, Name="Red Velvet Cream Cheese Cake", DisplayOrder=3},
                new Category { Id=4, Name= "Carrot Cake", DisplayOrder=4}
                );
        }
    }
}
