using Microsoft.EntityFrameworkCore;
using PizzaApi.Data.Entities;

namespace PizzaApi.Data
{
    public class PizzasDbContext : DbContext
    {
        public PizzasDbContext(DbContextOptions<PizzasDbContext> options)
            : base(options)
        {
        }

        public DbSet<PizzaEntity> Pizzas { get; set; } = null!;
    }
}