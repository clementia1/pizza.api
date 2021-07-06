using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PizzaApi.Data.Entities;
using PizzaApi.Data.EntityConfigurations;

namespace PizzaApi.Data
{
    public class PizzasDbContext : DbContext
    {
        public PizzasDbContext(DbContextOptions<PizzasDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryEntity> Categories { get; set; } = null!;
        public DbSet<IngredientEntity> Ingredients { get; set; } = null!;
        public DbSet<PizzaCategoryEntity> PizzaCategories { get; set; } = null!;
        public DbSet<PizzaEntity> Pizzas { get; set; } = null!;
        public DbSet<PizzaIngredientEntity> PizzaIngredients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new PizzaCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PizzaConfiguration());
            modelBuilder.ApplyConfiguration(new PizzaIngredientConfiguration());
        }
    }
}